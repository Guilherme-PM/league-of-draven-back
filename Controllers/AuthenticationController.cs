using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfDraven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<object> Login(LoginDTO login)
        {
            return await _authenticationService.Login(login);
        }
    }
}
