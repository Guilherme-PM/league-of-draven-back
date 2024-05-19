using LeagueOfDraven.DTO.Authentication;
using LeagueOfDraven.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AuthenticationService(
            TokenConfiguration tokenConfiguration,
            SigningConfiguration signingConfiguration,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingConfiguration = signingConfiguration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<object> Login(LoginDTO loginDto)
        {
            Microsoft.AspNetCore.Identity.SignInResult login = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, true, false);

            if (login.Succeeded)
            {
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

                return new { Token = token };
            }
            else
            {
                return new UnauthorizedObjectResult(new { Message = "Credenciais inválidas" });
            }
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
