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

        public class ChampionDataWrapper
        {
            public Dictionary<string, ChampionData>? Data { get; set; }
        }
    }
}
