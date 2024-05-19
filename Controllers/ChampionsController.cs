using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfDraven.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly IChampionsService _championsService;

        public ChampionsController(IChampionsService championsService)
        {
            _championsService = championsService;
        }

        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<object> GetAllChampions()
        {
            return await _championsService.GetAllChampions();
        }
    }
}
