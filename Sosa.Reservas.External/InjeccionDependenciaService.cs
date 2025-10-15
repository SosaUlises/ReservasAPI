using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sosa.Reservas.Application.DataBase;
using Sosa.Reservas.Application.External.GetTokenJWT;
using Sosa.Reservas.Application.External.SendGridEmail;
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


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            return services;
        }
    }
}
