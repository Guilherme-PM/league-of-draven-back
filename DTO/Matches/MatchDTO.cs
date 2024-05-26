namespace LeagueOfDraven.DTO.Matches
{
    public class MatchDTO
    {
        public string UserName { get; set; }
        public DateTime MatchDate { get; set; }
        public TimeSpan MatchDuration { get; set; }
        public int WonMatch { get; set; }
        public List<MatchPlayersDTO> Players { get; set; }
    }
}
