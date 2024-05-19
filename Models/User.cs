using Microsoft.AspNetCore.Identity;

namespace LeagueOfDraven.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string? PUUID { get; set; }
        public string? ProfileId { get; set; }
        public bool Active { get; set; }
    }
}
