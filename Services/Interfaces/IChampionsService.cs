using LeagueOfDraven.DTO.Champions;
using LeagueOfDraven.Models.RIOT.Champions;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface IChampionsService
    {
        Task<List<ChampionData>> GetAllChampions();
        Task<List<ChampionTagDTO>> GetChampionTagCounts();
    }
}
