using LeagueOfDraven.DTO.Summoner;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Repository.Interface
{
    public interface IUserMatchesRepository
    {
        Task AddUserMatchAsync(UserMatches userMatch);
        Task<UserMatches> GetUserMatchByIdAsync(string userMatchId);
        Task<UserMatches> GetMatchByIdAsync(string userMatchId);
        Task<int> TotalMatches();
        Task<int> TotalUsers();
        Task<SummonerDTO> GetTotalStatistics(string encryptedPUUID);
    }
}
