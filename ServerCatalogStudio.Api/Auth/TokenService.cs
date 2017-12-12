using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServerCatalogStudio.Api.Auth
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarToken(Usuario usuario)
        {
            var claims = GetClaims(usuario);
            var token = GenerateToken(claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateToken(Claim[] claims)
        {
            return new JwtSecurityToken(
                   claims: claims,
                   expires: DateTime.UtcNow.AddDays(60),
                   notBefore: DateTime.UtcNow,
                   issuer: "Fiver.Security.Bearer",
                   audience: "Fiver.Security.Bearer",
                   signingCredentials: GetSigningCredentials()
             );
        }

        private Claim[] GetClaims(Usuario usuario)
        {
            return new[]{
                new Claim(JwtRegisteredClaimNames.NameId,usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),
                           SecurityAlgorithms.HmacSha256);
        }

    }
}
