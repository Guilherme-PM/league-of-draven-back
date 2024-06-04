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
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int VisionScore { get; set; }
        public int WardsPlaced { get; set; }
        public int WardsKilled { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public string Lane { get; set; }
        public string Role { get; set; }
        public List<MatchesPlayerItems> Items { get; set; } = new List<MatchesPlayerItems>();
        public UserMatches UserMatch { get; set; }
    }
}
