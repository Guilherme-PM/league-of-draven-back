namespace LeagueOfDraven.Models
{
    public class UserMatches
    {
        public string UserMatchId { get; set; }
        public string Puuid { get; set; }
        public string UserName { get; set; }
        public DateTime MatchDate { get; set; }
        public TimeSpan MatchDuration { get; set; }
        public string GameMode { get; set; }
        public List<MatchesChampions> Champions { get; set; } = new List<MatchesChampions>();
        public List<MatchesPlayerStatistics> PlayerStatistics { get; set; } = new List<MatchesPlayerStatistics>();
    }
}
