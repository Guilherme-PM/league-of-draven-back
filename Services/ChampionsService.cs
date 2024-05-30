using LeagueOfDraven.DTO.Champions;
using LeagueOfDraven.DTO.Summoner;
using LeagueOfDraven.Models.RIOT.Champions;
using LeagueOfDraven.Services.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;

namespace LeagueOfDraven.Services
{
    public class ChampionsService : IChampionsService
    {
        private readonly RiotApiService _riotApiService;

        public ChampionsService(RiotApiService riotApiService)
        {
            _riotApiService = riotApiService;
        }

        public async Task<List<ChampionData>> GetAllChampions()
        {
            string url = "https://ddragon.leagueoflegends.com/cdn/14.10.1/data/pt_BR/champion.json";
            var json = await _riotApiService.GetDataDragonAsync(url);

            if (json == null)
                throw new Exception("Api sem retorno");

            var championDataWrapper = JsonConvert.DeserializeObject<ChampionDataWrapper>(json);

            if (championDataWrapper == null || championDataWrapper.Data == null)
                throw new Exception("Dados de campeões não encontrados");

            return championDataWrapper.Data.Values.ToList();
        }

        public async Task<ChampionData> GetChampionByID(int championID)
        {
            List<ChampionData> champions = await GetAllChampions();

            ChampionData champion = champions.Where(x => x.Key == championID).FirstOrDefault();

            return champion;
        }

        public async Task<List<ChampionTagDTO>> GetChampionTagCounts()
        {
            var champions = await GetAllChampions();

            Dictionary<string, int> tagCounts = new Dictionary<string, int>();

            foreach (var champion in champions)
            {
                foreach (var tag in champion.Tags)
                {
                    if (tagCounts.ContainsKey(tag))              
                        tagCounts[tag]++;              
                    else              
                        tagCounts[tag] = 1;             
                }
            }

            List<ChampionTagDTO> tags = tagCounts.Select(tc => new ChampionTagDTO
            {
                Tag = tc.Key,
                Count = tc.Value
            }).ToList();

            return tags;
        }

        public async Task<List<ChampionMasteries>> GetMasteriesChampionsByPUUID(string encryptedPUUID)
        {
            if (string.IsNullOrEmpty(encryptedPUUID))
                throw new ArgumentException("encryptedPUUID deve ser fornecido");

            string endpoint = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}";
            List<ChampionMasteries> championMasteries = await _riotApiService.GetAsyncByRegion<List<ChampionMasteries>>(endpoint);

            if (championMasteries == null)
                throw new Exception("Não foi encontrado nenhuma maestria de campeões");

            return championMasteries;
        }

        public class ChampionDataWrapper
        {
            public Dictionary<string, ChampionData> Data { get; set; }
        }
    }
}
