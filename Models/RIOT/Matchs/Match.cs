namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class Match
    {
        public string MatchId { get; set; }
        public MatchMetadata MetaData { get; set; }
        public MatchInfo Info { get; set; }
    }
}
