namespace LeagueOfDraven.Models
{
    public class MatchesChampions
    {
        public string UserMatchId { get; set; }
        public long ParticipantId { get; set; }
        public string ChampionName { get; set; }
        public string UserName { get; set; }
        public string Puuid { get; set; }
        public UserMatches UserMatch { get; set; }
    }
}
