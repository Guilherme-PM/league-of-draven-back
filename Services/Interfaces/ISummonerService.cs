using LeagueOfDraven.DTO.Summoner;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface ISummonerService
    {
        Task<SummonerPuuidDTO> GetSummonerByNameAsync(string gameName, string tagLine);
        Task<SummonerPuuidDTO> GetSummonerByPUUID(string encryptedPUUID);
    }
}
