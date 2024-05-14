using LeagueOfDraven.Models;
using LeagueOfDraven.Repository.Interface;
using System.Security.Cryptography;
using System.Text;

namespace LeagueOfDraven.Services
{
    public class UserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> RegisterUser(User user)
        {
            await _userRepository.InsertUser(user);

            return "DEU";
        }
    }
}
