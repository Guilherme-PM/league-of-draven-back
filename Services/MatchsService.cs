using AutoMapper;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.Models.RIOT.Matchs;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services.Interfaces;
using System.Diagnostics;
using System.Net.Http;

namespace LeagueOfDraven.Services
{
    public class MatchsService : IMatchsService
    {
        private readonly RiotApiService _riotApiService;
        private readonly IUserMatchesRepository _userMatchesRepository;
        private readonly IMapper _mapper;

        public MatchsService(RiotApiService riotApiService, IUserMatchesRepository userMatchesRepository, IMapper mapper)
        {
            _riotApiService = riotApiService;
            _userMatchesRepository = userMatchesRepository;
            _mapper = mapper;
        }

        public async Task<List<string>> GetMatchIds(string puuid)
        {
            string endpoint = $"/lol/match/v5/matches/by-puuid/{puuid}/ids";
            List<string> matches = await _riotApiService.GetAsync<List<string>>(endpoint);

            return matches;
        }

        public async Task<Match> GetMatchDataAsync(string matchId)
        {
            string endpoint = $"/lol/match/v5/matches/{matchId}";
            Match match = await _riotApiService.GetAsync<Match>(endpoint);
            return match;
        }

        public async Task<MatchDTO> GetMatch(string matchId)
        {
            var match = await _userMatchesRepository.GetMatchByIdAsync(matchId);

            MatchDTO matchDTO = _mapper.Map<MatchDTO>(match);

            return matchDTO;
        }
    }
}
