namespace LeagueOfDraven.Services.Interfaces
{
    public interface ISummonerService
    {
        Task<string> GetSummonerByNameAsync(string summonerName, string tagLine);
    }
}
