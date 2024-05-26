using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfDraven.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class MatchsController
    {
        private readonly IMatchsService _matchsService;

        public MatchsController(IMatchsService matchsService)
        {
            _matchsService = matchsService;
        }

        [HttpGet]
        [Authorize]
        [Route("[action]/{matchId}")]
        public async Task<object> GetMatch(string matchId)

        {
            return await _matchsService.GetMatch(matchId);
        }
    }
}
