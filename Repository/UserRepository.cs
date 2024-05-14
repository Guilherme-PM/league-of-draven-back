using LeagueOfDraven.Data;
using LeagueOfDraven.Models;
using System.Reflection;

namespace LeagueOfDraven.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<User> InsertUser(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
