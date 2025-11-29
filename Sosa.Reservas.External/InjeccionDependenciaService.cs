using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sosa.Reservas.Application.DataBase;
using Sosa.Reservas.Application.External.GetTokenJWT;
using Sosa.Reservas.Application.External.SendGridEmail;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.External.GetTokenJWT;
using Sosa.Reservas.External.SendGridEmail;
using Sosa.Reservas.Persistence.DataBase;
using System.Text;

namespace Sosa.Reservas.External
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Conexion DB (PostgreSQL)

            var connectionString = configuration.GetConnectionString("SQLConnectionStrings");

            services.AddDbContext<DataBaseService>(options =>
                options.UseNpgsql(connectionString)
            );

            // Inyecciones de dependencia servicios
            services.AddScoped<IDataBaseService, DataBaseService>();
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            services.AddSingleton<IGetTokenJWTService, GetTokenJWTService>();


            // Identity
            services.AddIdentity<UsuarioEntity, IdentityRole<int>>(options =>
            {
                // Configuración de Contraseña
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<DataBaseService>()
                .AddDefaultTokenProviders();



            // Leemos los valores de JWT en variables para validarlos
            var jwtIssuer = configuration["Jwt_Issuer"];
            var jwtAudience = configuration["Jwt_Audience"];
            var jwtKey = configuration["Jwt_Key"];

            if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience) || string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("La configuración de JWT (Issuer, Audience, Key) no está completa.");
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });


            // Servicios JWT

            services.AddScoped<IGetTokenJWTService, GetTokenJWTService>();

            return services;
        }
    }
}
