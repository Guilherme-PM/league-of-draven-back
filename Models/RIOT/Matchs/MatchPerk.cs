namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchPerk
    {
        public long PerkId { get; set; }
        public long MatchId { get; set; }
        public long ParticipantId { get; set; }
        public List<MatchStatPerk> StatPerks { get; set; } = new List<MatchStatPerk>();
        public List<MatchStyle> Styles { get; set; } = new List<MatchStyle>();
    }
}
