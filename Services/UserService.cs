using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Models;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LeagueOfDraven.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<object> RegisterUser(LoginDTO registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Active = true
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                return result.Errors;
            }
        }
    }
}
