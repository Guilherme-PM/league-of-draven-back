namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchStyle
    {
        public long MatchId {  get; set; }
        public long ParticipantId { get; set; }
        public long PerkId { get; set; }
        public long StyleId { get; set; }
        public string Description { get; set; }
        public List<MatchSelection> Selections { get; set; } = new List<MatchSelection>();
    }
}
