using LeagueOfDraven.Data;
using LeagueOfDraven.Models;
using LeagueOfDraven.Repository.Interface;

namespace LeagueOfDraven.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> RegisterUser(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
