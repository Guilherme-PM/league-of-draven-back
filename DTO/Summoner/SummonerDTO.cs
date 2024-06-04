using LeagueOfDraven.DTO.Matches;

namespace LeagueOfDraven.DTO.Summoner
{
    public class SummonerDTO
    {
        public string BackgroundImage { get; set; }
        public string MostPlayedChampion { get; set; }
        public int MostPlayedChampionCount { get; set; }
        public string Username { get; set; }
        public int SummonerLevel { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalDamage { get; set; }
        public int TotalDamageChampions { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalGoldEarned { get; set; }
        public SummonerRankedDTO SummonerRankedDTO { get; set; }
        public SummonerMasteryDTO SummonerMasteryDTO { get; set; }
        public List<LatestMatchesDTO> LatestMatchesKillsDeathsDTO { get; set; }
    }
}
