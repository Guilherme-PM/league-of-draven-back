﻿using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoImobiliario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly ISummonerService _summonerService;

        public SummonerController(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [HttpGet]
        [Route("[action]/{gameName}/{tagLine}")]
        public async Task<object> GetSummonerByNameAsync(string gameName, string tagLine)
        {
            return await _summonerService.GetSummonerByNameAsync(gameName, tagLine);
        }
    }
}