using LeagueOfDraven.Models;

namespace LeagueOfDraven.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
    }
}
