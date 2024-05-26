namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchSpell
    {
        public long SpellId { get; set; }
        public int SpellNumber { get; set; }
        public int Casts { get; set; }
        public long ParticipantId { get; set; }
        public MatchParticipant Participant { get; set; }
    }
}
