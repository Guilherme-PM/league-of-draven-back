using LeagueOfDraven.Data;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.DTO.Summoner;
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

        public async Task<SummonerDTO> GetTotalStatistics(string encryptedPUUID)
        {
            var totalDeaths = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.Deaths);
            var totalKills = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.Kills);
            var totalDamage = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.TotalDamageDealt);
            var totalDamageChampions = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.TotalDamageDealtToChampions);
            var totalDamageTaken = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.TotalDamageTaken);
            var totalGoldEarned = await _dbContext.MatchesPlayerStatistics.Where(x => x.Puuid == encryptedPUUID).SumAsync(x => x.GoldEarned);

            return new SummonerDTO
            {
                TotalDeaths = totalDeaths,
                TotalKills = totalKills,
                TotalDamage = totalDamage,
                TotalDamageChampions = totalDamageChampions,
                TotalDamageTaken = totalDamageTaken,
                TotalGoldEarned = totalGoldEarned
            };
        }

        public async Task<List<UserMatches>> GetLatestMatchesKillsDeaths(string encryptedPUUID)
        {
            var matches = await _dbContext.UserMatches.Include(x => x.PlayerStatistics).Include(x => x.Champions).Where(x => x.Puuid == encryptedPUUID).OrderByDescending(x => x.MatchDate).Take(10).ToListAsync();

            return matches;
        }
    }
}
