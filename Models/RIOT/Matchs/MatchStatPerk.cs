namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchStatPerk
    {
        public long StatPerkId { get; set; }
        public long PerkId { get; set; }
        public int Defense { get; set; }
        public int Flex { get; set; }
        public int Offense { get; set; }
    }
}
