using AutoMapper;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.DTO.Summoner;
using LeagueOfDraven.Models;
using LeagueOfDraven.Models.RIOT.Champions;
using LeagueOfDraven.Models.RIOT.Matchs;
using LeagueOfDraven.Models.RIOT.Summoner;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace LeagueOfDraven.Services
{
    public class SummonerService : ISummonerService
    {
        private readonly RiotApiService _riotApiService;
        private readonly IMatchesService _matchsService;
        private readonly IUserMatchesRepository _userMatchesRepository;
        private readonly IMatchesChampionsRepository _matchesChampionsRepository;
        private readonly IChampionsService _championsService;
        private readonly IMapper _mapper;

        public SummonerService(RiotApiService riotApiService, 
                               IMatchesService matchsService, 
                               IUserMatchesRepository userMatchesRepository, 
                               IMatchesChampionsRepository matchesChampionsRepository,
                               IChampionsService championsService,
                               IMapper mapper)
        {
            _riotApiService = riotApiService;
            _matchsService = matchsService;
            _userMatchesRepository = userMatchesRepository;
            _matchesChampionsRepository = matchesChampionsRepository;
            _championsService = championsService;
            _mapper = mapper;
        }

        public async Task<SummonerAccountDTO> GetSummonerByNameAsync(string gameName, string tagLine)
        {
            if(string.IsNullOrEmpty(gameName) || string.IsNullOrEmpty(tagLine))
                throw new ArgumentException("gameName e tagLine devem ser fornecidos.");

            string endpoint = $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
            SummonerAccountDTO summoner = await _riotApiService.GetAsync<SummonerAccountDTO>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }

        public async Task<object> AddMatchesDatabase(string gameName, string tagLine)
        {
            if (string.IsNullOrEmpty(gameName) || string.IsNullOrEmpty(tagLine))
                throw new ArgumentException("gameName e tagLine devem ser fornecidos.");

            string endpoint = $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
            SummonerAccountDTO summoner = await _riotApiService.GetAsync<SummonerAccountDTO>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            List<string> matches = await _matchsService.GetMatchIds(summoner.Puuid);

            foreach (var matchId in matches)
            {
                var matchVerification = await _userMatchesRepository.GetUserMatchByIdAsync(matchId);

                if (matchVerification == null)
                {
                    var match = await _matchsService.GetMatchDataAsync(matchId);
                    await InsertMatchData(match, summoner);
                }
            }

            return "Dados inseridos com sucesso";
        }

        public async Task InsertMatchData(Match match, SummonerAccountDTO summoner)
        {
            try
            {
                var championsTasks = match.Info.Participants.Select(async p =>
                {
                    SummonerAccountDTO summonerInfo;

                    if (p.Puuid == "BOT")
                    {
                        summonerInfo = new SummonerAccountDTO
                        {
                            GameName = "BOT",
                            TagLine = "BOT"
                        };
                    }
                    else
                    {
                        summonerInfo = await GetSummonerByPUUID(p.Puuid);
                        await Task.Delay(1000);
                    }

                    return new MatchesChampions
                    {
                        Puuid = p.Puuid,
                        ChampionName = p.ChampionName,
                        UserName = summonerInfo.GameName + "#" + summonerInfo.TagLine,
                        UserMatchId = match.MetaData.MatchId,
                        ParticipantId = p.ParticipantId
                    };
                }).ToList();

                var champions = await Task.WhenAll(championsTasks);

                var playerStatisticsTasks = match.Info.Participants.Select(async p => new MatchesPlayerStatistics
                {
                    Puuid = p.Puuid,
                    UserMatchId = match.MetaData.MatchId,
                    ParticipantId = p.ParticipantId,
                    Items = await GetPlayerItems(p, match.MetaData.MatchId),
                    Farm = p.TotalMinionsKilled,
                    Deaths = p.Deaths,
                    Lane = p.Lane,
                    Role = p.Role,
                    TotalDamageDealt = p.TotalDamageDealt,
                    TotalDamageDealtToChampions = p.TotalDamageDealtToChampions,
                    TotalDamageTaken = p.TotalDamageTaken,
                    TotalHeal = p.TotalHeal,
                    VisionScore = p.VisionScore,
                    WardsKilled = p.WardsKilled,
                    WardsPlaced = p.WardsPlaced,
                    Kills = p.Kills,
                    GoldEarned = p.GoldEarned,
                    GoldSpent = p.GoldSpent,
                    WonMatch = p.Win
                }).ToList();

                var playerStatistics = await Task.WhenAll(playerStatisticsTasks);

                var userMatch = new UserMatches
                {
                    Puuid = summoner.Puuid,
                    UserName = summoner.GameName + "#" + summoner.TagLine,
                    UserMatchId = match.MetaData.MatchId,
                    GameMode = match.Info.GameMode,
                    MatchDate = DateTimeOffset.FromUnixTimeMilliseconds(match.Info.GameCreation).DateTime,
                    MatchDuration = TimeSpan.FromSeconds(match.Info.GameDuration),
                    Champions = champions.ToList(),
                    PlayerStatistics = playerStatistics.ToList()
                };

                await _userMatchesRepository.AddUserMatchAsync(userMatch);
            } catch (Exception ex)
            {
                if (ex.Message.Contains("TooManyRequests"))
                {
                    throw new Exception("Ocorreu um erro: Muitas requisições. Tente novamente mais tarde." + summoner);
                }
                else
                {
                    throw new Exception("Ocorreu um erro interno no sistema: " + ex.Message);
                }
            }
        }

        public async Task<List<MatchesPlayerItems>> GetPlayerItems(MatchParticipant participant, string matchId)
        {
            var items = new List<MatchesPlayerItems>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Json", "items.json");
            var json = _riotApiService.LoadLocalDataDragonJson(filePath);

            JObject itemData = JObject.Parse(json);

            for (int i = 0; i <= 6; i++)
            {
                var itemId = (int)typeof(MatchParticipant).GetProperty($"Item{i}").GetValue(participant);
                if (itemId != 0)
                {
                    var itemName = itemData["data"][itemId.ToString()]["name"].ToString();
                    items.Add(new MatchesPlayerItems
                    {
                        UserMatchId = matchId,
                        ParticipantId = participant.ParticipantId,
                        ItemName = itemName,
                        ItemId = itemId,
                    });
                }
            }

            return items;
        }

        public async Task<SummonerAccountDTO> GetSummonerByPUUID(string encryptedPUUID)
        {
            if (string.IsNullOrEmpty(encryptedPUUID))
                throw new ArgumentException("encryptedPUUID deve ser fornecido");

            string endpoint = $"/riot/account/v1/accounts/by-puuid/{encryptedPUUID}";
            var summoner = await _riotApiService.GetAsync<SummonerAccountDTO>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }

        public async Task<SummonerLevelAccount> GetSummonerLevel(string encryptedPUUID)
        {
            if (string.IsNullOrEmpty(encryptedPUUID))
                throw new ArgumentException("encryptedPUUID deve ser fornecido");

            string endpoint = $"/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
            var summoner = await _riotApiService.GetAsyncByRegion<SummonerLevelAccount>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }

        public async Task<SummonerRankedDTO> GetSummonerLeague(string encryptedSummonerId)
        {
            if (string.IsNullOrEmpty(encryptedSummonerId))
                throw new ArgumentException("encryptedSummonerId deve ser fornecido");

            string endpoint = $"/lol/league/v4/entries/by-summoner/{encryptedSummonerId}";
            List<SummonerRankedDTO> summoner = await _riotApiService.GetAsyncByRegion<List<SummonerRankedDTO>>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            if (summoner.Count == 0)
                return null;

            return summoner[0];
        }

        public async Task<SummonerDTO> GetSummonerDashboard(string encryptedPUUID)
        {
            SummonerAccountDTO summonerAccount = await GetSummonerByPUUID(encryptedPUUID);
            SummonerLevelAccount summonerPuuid = await GetSummonerLevel(encryptedPUUID);
            SummonerRankedDTO summonerRanked = await GetSummonerLeague(summonerPuuid.Id);
            List<ChampionMasteries> championMasteries = await _championsService.GetMasteriesChampionsByPUUID(encryptedPUUID);

            SummonerMasteryDTO championHighestMastery = _mapper.Map<SummonerMasteryDTO>(championMasteries[0]);

            var mostPlayedChampion = await _matchesChampionsRepository.GetTotalMatchesChampionByPUUID(encryptedPUUID);

            ChampionData champion = await _championsService.GetChampionByID(championMasteries[0].ChampionId);
            SummonerDTO totals = await _userMatchesRepository.GetTotalStatistics(encryptedPUUID);

            SummonerDTO summoner = new()
            {
                Username = summonerAccount.GameName + "#" + summonerAccount.TagLine,
                SummonerLevel = summonerPuuid.SummonerLevel,
                MostPlayedChampion = mostPlayedChampion.ChampionName,
                MostPlayedChampionCount = mostPlayedChampion.Count,
                TotalDeaths = totals.TotalDeaths,
                TotalKills = totals.TotalKills,
                TotalDamage = totals.TotalDamage,
                TotalDamageChampions = totals.TotalDamageChampions,
                TotalDamageTaken = totals.TotalDamageTaken,
                TotalGoldEarned = totals.TotalGoldEarned,
                BackgroundImage = $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{mostPlayedChampion.ChampionName}_0.jpg"
            };
            
            if(summonerRanked != null)
            {
                summoner.SummonerRankedDTO = new()
                {
                    Tier = summonerRanked.Tier,
                    Rank = summonerRanked.Rank,
                    LeaguePoints = summonerRanked.LeaguePoints,
                    Wins = summonerRanked.Wins,
                    Losses = summonerRanked.Losses,
                };
            }

            if(championMasteries != null)
            {
                summoner.SummonerMasteryDTO = new()
                {
                    ChampionName = champion.Name,
                    ChampionLevel = championHighestMastery.ChampionLevel,
                    ChampionPoints = championHighestMastery.ChampionPoints,
                    ChampionImage = $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{champion.Name}_0.jpg"
                };
            }

            return summoner;
        }
    }
}
