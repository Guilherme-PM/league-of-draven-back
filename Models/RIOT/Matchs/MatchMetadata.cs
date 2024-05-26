namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchMetadata
    {
        public string DataVersion { get; set; }
        public string MatchId { get; set; }
        public List<string> Participants { get; set; }
    }
}
