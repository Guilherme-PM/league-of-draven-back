using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface IUserService
    {
        Task<object> RegisterUser(LoginDTO registerDto);
    }
}
