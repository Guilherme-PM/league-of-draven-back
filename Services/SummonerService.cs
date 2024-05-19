using LeagueOfDraven.Services.Interfaces;

namespace LeagueOfDraven.Services
{
    public class SummonerService : ISummonerService
    {
        private readonly RiotApiService _riotApiService;

        public SummonerService(RiotApiService riotApiService)
        {
            _riotApiService = riotApiService;
        }

        public async Task<string> GetSummonerByNameAsync(string gameName, string tagLine)
        {
            if(string.IsNullOrEmpty(gameName) || string.IsNullOrEmpty(tagLine))
                throw new ArgumentException("gameName e tagLine devem ser fornecidos.");

            string endpoint = $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
            var summoner = await _riotApiService.GetAsync(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }

        public async Task<object> GetSummonerByPUUID(string encryptedPUUID)
        {
            if (string.IsNullOrEmpty(encryptedPUUID))
                throw new ArgumentException("encryptedPUUID deve ser fornecido");

            string endpoint = $"/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
            var summoner = await _riotApiService.GetAsync(endpoint);

            if (summoner == null)
                throw new Exception("Summoner não encontrado");

            return summoner;
        }
    }
}
