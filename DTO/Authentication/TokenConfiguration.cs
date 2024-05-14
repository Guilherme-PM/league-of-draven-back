namespace LeagueOfDraven.DTO.Authentication
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double Seconds { get; set; }
        public double ExternalSeconds { get; set; }
        public string Secret { get; set; }
        public string AESPasswordResetKey { get; set; }
    }
}
