using LeagueOfDraven.DTO.Dashboard;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.Models.RIOT.Matchs;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface IMatchesService
    {
        Task<List<string>> GetMatchIds(string puuid);
        Task<Match> GetMatchDataAsync(string matchId);
        Task<MatchDTO> GetMatch(string matchId);
        Task<TotalMatchesAndUsersDTO> TotalMatchesAndUsers();

    }
}
