namespace LeagueOfDraven.DTO.Authentication
{
    public class ExternalAPITokenDTO
    {
        public string? Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
    }
}
