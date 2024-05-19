using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Models;
using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfDraven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _useService;

        public UserController(IUserService useService)
        {
            _useService = useService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<object> RegisterUser(LoginDTO user)
        {
            return await _useService.RegisterUser(user);
        }
    }
}
