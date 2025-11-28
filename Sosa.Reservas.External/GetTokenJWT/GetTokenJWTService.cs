using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sosa.Reservas.Application.External.GetTokenJWT;
using Sosa.Reservas.Domain.Entidades.Usuario;
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

        public string Execute(string userId, string role, UsuarioEntity usuario)
        {
            // Variables de configuración
            var jwtKey = _configuration["Jwt_Key"];
            var jwtIssuer = _configuration["Jwt_Issuer"];
            var jwtAudience = _configuration["Jwt_Audience"];

            if (string.IsNullOrEmpty(jwtKey) ||
                string.IsNullOrEmpty(jwtIssuer) ||
                string.IsNullOrEmpty(jwtAudience))
            {
                throw new InvalidOperationException("JWT mal configurado.");
            }

            // Handler y firma
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            // Claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim("Nombre", usuario.Nombre),
            new Claim("Apellido", usuario.Apellido),
        };

            if (!string.IsNullOrEmpty(role))
                claims.Add(new Claim(ClaimTypes.Role, role));

            // Descriptor del token
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Issuer = jwtIssuer,
                Audience = jwtAudience
            };

            // Generación
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}