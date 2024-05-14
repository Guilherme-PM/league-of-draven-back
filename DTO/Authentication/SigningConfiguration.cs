using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LeagueOfDraven.DTO.Authentication
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public SigningConfiguration(TokenConfiguration tokenConfiguration)
        {
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
