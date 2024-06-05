namespace LeagueOfDraven.DTO.Matches
{
    public class LatestMatchesDTO
    {
        public string MatchId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int Farm { get; set; }
        public int Gold { get; set; }
        public string Gamemode { get; set; }
        public string Lane { get; set; }
        public string Role { get; set; }
        public string MatchDate { get; set; }
        public bool Win { get; set; }
        public string ChampionImage { get; set; }
    }
}
