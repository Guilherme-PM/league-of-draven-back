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
        private readonly IMatchesService _matchsService;

        public MatchsController(IMatchesService matchsService)
        {
            _matchsService = matchsService;
        }

        [HttpGet]
        [Route("[action]/{matchId}")]
        public async Task<object> GetMatch(string matchId)
        {
            return await _matchsService.GetMatch(matchId);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<object> TotalMatchesAndUsers()
        {
            return await _matchsService.TotalMatchesAndUsers();
        }
    }
}
