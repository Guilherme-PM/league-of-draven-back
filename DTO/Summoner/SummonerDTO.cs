namespace LeagueOfDraven.DTO.Summoner
{
    public class SummonerDTO
    {
        public string BackgroundImage { get; set; }
        public string MostPlayedChampion { get; set; }
        public int MostPlayedChampionCount { get; set; }
        public string Username { get; set; }
        public int SummonerLevel { get; set; }
        public SummonerRankedDTO SummonerRankedDTO { get; set; }
        public SummonerMasteryDTO SummonerMasteryDTO { get; set; }
    }
}
