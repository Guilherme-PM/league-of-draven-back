using LeagueOfDraven.DTO.Matches;

namespace LeagueOfDraven.Repository.Interface
{
    public interface IMatchesChampionsRepository
    {
        Task<MatchesChampionCountDTO> GetTotalMatchesChampionByPUUID(string encryptedPUUID);
    }
}
