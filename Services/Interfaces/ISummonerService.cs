using LeagueOfDraven.DTO.Summoner;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface ISummonerService
    {
        Task<SummonerAccountDTO> GetSummonerByNameAsync(string gameName, string tagLine);
        Task<SummonerAccountDTO> GetSummonerByPUUID(string encryptedPUUID);
        Task<SummonerDTO> GetSummonerDashboard(string encryptedPUUID);
        Task<object> AddMatchesDatabase(string gameName, string tagLine);
    }
}
