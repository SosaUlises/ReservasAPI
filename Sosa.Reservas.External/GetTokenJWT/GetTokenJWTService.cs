using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sosa.Reservas.Application.External.GetTokenJWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sosa.Reservas.External.GetTokenJWT
{
    public class GetTokenJWTService : IGetTokenJWTService
    {
        private readonly IConfiguration _configuration;

        public GetTokenJWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute(string id, string role)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            {
                throw new InvalidOperationException("La clave, el emisor o la audiencia de JWT no están configurados correctamente.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id)
            };

            if (!string.IsNullOrEmpty(role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), 
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtIssuer,
                Audience = jwtAudience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}