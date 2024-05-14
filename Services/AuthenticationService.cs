using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace LeagueOfDraven.Services
{
    public class AuthenticationService
    {
        private TokenConfiguration _tokenConfiguration;
        private SigningConfiguration _signingConfiguration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public async Task<object> Login(LoginDTO loginDto)
        {
            SignInResult login = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, true, false);

            var baseUser = new User();
            baseUser = await _userManager.FindByNameAsync(loginDto.Username);

            if (baseUser == null)
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            else if (baseUser != null && !baseUser.Active)
                return new Exception("Usuário inativado");

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
            string token = CreateToken(createDate, expirationDate);

            return true;
        }

        public async Task<object> GenerateToken()
        {
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.ExternalSeconds);
            string token = CreateToken(createDate, expirationDate);

            return new ExternalAPITokenDTO()
            {
                Created = createDate,
                Expiration = expirationDate,
                Token = token
            };
        }

        protected string CreateToken(DateTime createDate, DateTime expirationDate)
        {
            var handler = new JwtSecurityTokenHandler();
            var security = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(security);
            return token;
        }
    }
}
