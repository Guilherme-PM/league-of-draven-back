namespace LeagueOfDraven.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PUUID { get; set; }
        public string? ProfileId { get; set; }
        public bool Active { get; set; }
    }
}
