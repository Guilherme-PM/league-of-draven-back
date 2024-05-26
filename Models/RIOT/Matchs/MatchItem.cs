namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchItem
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public long ParticipantId { get; set; }
        public MatchParticipant Participant { get; set; }
    }
}
