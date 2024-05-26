using LeagueOfDraven.Models;

namespace LeagueOfDraven.Repository.Interface
{
    public interface IUserMatchesRepository
    {
        Task AddUserMatchAsync(UserMatches userMatch);
        Task<UserMatches> GetUserMatchByIdAsync(string userMatchId);
        Task<UserMatches> GetMatchByIdAsync(string userMatchId);
    }
}
