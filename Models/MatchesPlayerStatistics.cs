namespace LeagueOfDraven.Models
{
    public class MatchesPlayerStatistics
    {
        public string UserMatchId { get; set; }
        public long ParticipantId { get; set; }
        public string Puuid { get; set; }
        public int Farm { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public bool WonMatch { get; set; }
        public bool WonLane { get; set; }
        public List<MatchesPlayerItems> Items { get; set; } = new List<MatchesPlayerItems>();
        public UserMatches UserMatch { get; set; }
    }
}
