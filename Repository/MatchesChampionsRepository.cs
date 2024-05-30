using LeagueOfDraven.Data;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.Models;
using LeagueOfDraven.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfDraven.Repository
{
    public class MatchesChampionsRepository : IMatchesChampionsRepository
    {
        private readonly AppDbContext _dbContext;

        public MatchesChampionsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MatchesChampionCountDTO> GetTotalMatchesChampionByPUUID(string encryptedPUUID)
        {
            return await _dbContext.MatchesChampions.Where(x => x.Puuid == encryptedPUUID).GroupBy(y => y.ChampionName).Select(z => new MatchesChampionCountDTO
            {
                ChampionName = z.Key,
                Count = z.Count()
            }).OrderByDescending(xx => xx.Count).FirstOrDefaultAsync();
        }
    }
}
