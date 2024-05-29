using LeagueOfDraven.DTO.Summoner;
using LeagueOfDraven.Models;
using LeagueOfDraven.Models.RIOT.Matchs;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace LeagueOfDraven.Services
{
    public class SummonerService : ISummonerService
    {
        private readonly RiotApiService _riotApiService;
        private readonly IMatchsService _matchsService;
        private readonly IUserMatchesRepository _userMatchesRepository;

        public SummonerService(RiotApiService riotApiService, IMatchsService matchsService, IUserMatchesRepository userMatchesRepository)
        {
            _riotApiService = riotApiService;
            _matchsService = matchsService;
            _userMatchesRepository = userMatchesRepository;
        }

        public async Task<SummonerPuuidDTO> GetSummonerByNameAsync(string gameName, string tagLine)
        {
            if(string.IsNullOrEmpty(gameName) || string.IsNullOrEmpty(tagLine))
                throw new ArgumentException("gameName e tagLine devem ser fornecidos.");

            string endpoint = $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
            SummonerPuuidDTO summoner = await _riotApiService.GetAsync<SummonerPuuidDTO>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            List<string> matches = await _matchsService.GetMatchIds(summoner.Puuid);

            foreach (var matchId in matches)
            {
                var matchVerification = await _userMatchesRepository.GetUserMatchByIdAsync(matchId);

                if(matchVerification == null)
                {
                    var match = await _matchsService.GetMatchDataAsync(matchId);
                    await InsertMatchData(match, summoner);
                    await Task.Delay(100);
                }
            }

            return summoner;
        }

        public async Task InsertMatchData(Match match, SummonerPuuidDTO summoner)
        {
            var championsTasks = match.Info.Participants.Select(async p =>
            {
                SummonerPuuidDTO summonerInfo;

                if (p.Puuid == "BOT")
                {
                    summonerInfo = new SummonerPuuidDTO
                    {
                        GameName = "BOT",
                        TagLine = "BOT"
                    };
                }
                else
                    summonerInfo = await GetSummonerByPUUID(p.Puuid);            

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
                MatchDate = DateTimeOffset.FromUnixTimeMilliseconds(match.Info.GameCreation).DateTime,
                MatchDuration = TimeSpan.FromSeconds(match.Info.GameDuration),
                Champions = champions.ToList(),
                PlayerStatistics = playerStatistics.ToList()
            };

            await _userMatchesRepository.AddUserMatchAsync(userMatch);
        }

        public async Task<List<MatchesPlayerItems>> GetPlayerItems(MatchParticipant participant, string matchId)
        {
            var items = new List<MatchesPlayerItems>();
            string filePath = @"G:\Projetos\league-of-draven-back\Data\Json\items.json"; // Arrumar essa merda depois
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

        public async Task<SummonerPuuidDTO> GetSummonerByPUUID(string encryptedPUUID)
        {
            if (string.IsNullOrEmpty(encryptedPUUID))
                throw new ArgumentException("encryptedPUUID deve ser fornecido");

            string endpoint = $"/riot/account/v1/accounts/by-puuid/{encryptedPUUID}";
            var summoner = await _riotApiService.GetAsync<SummonerPuuidDTO>(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }
    }
}
