using LeagueOfDraven.Data;
using LeagueOfDraven.Models;
using LeagueOfDraven.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfDraven.Repository
{
    public class UserMatchesRepository : IUserMatchesRepository
    {
        private readonly AppDbContext _dbContext;

        public UserMatchesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserMatchAsync(UserMatches userMatch)
        {
            await _dbContext.UserMatches.AddAsync(userMatch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserMatches> GetUserMatchByIdAsync(string userMatchId)
        {
            return await _dbContext.UserMatches.FirstOrDefaultAsync(um => um.UserMatchId == userMatchId);
        }

        public async Task<UserMatches> GetMatchByIdAsync(string userMatchId)
        {
            return await _dbContext.UserMatches.Include(x => x.PlayerStatistics).ThenInclude(x => x.Items).Include(x => x.Champions)
                .FirstOrDefaultAsync(um => um.UserMatchId == userMatchId);
        }

        public async Task<int> TotalMatches()
        {
            return await _dbContext.UserMatches.Select(x => x.Puuid).CountAsync();
        }

        public async Task<int> TotalUsers()
        {
            return await _dbContext.UserMatches.Select(x => x.Puuid).Distinct().CountAsync();
        }
    }
}
