using LeagueOfDraven.Models.RIOT.Champions;

namespace LeagueOfDraven.Services.Interfaces
{
    public interface IChampionsService
    {
        Task<List<ChampionData>> GetAllChampions();
    }
}
