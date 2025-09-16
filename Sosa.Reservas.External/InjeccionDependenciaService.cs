using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.DataBase;
using Sosa.Reservas.Application.External.SendGridEmail;
using Sosa.Reservas.External.SendGridEmail;
using Sosa.Reservas.Persistence.DataBase;

namespace Sosa.Reservas.External
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Conexion Db
            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SQLConnectionStrings")));

            // Inyecciones de dependencia servicios
            services.AddScoped<IDataBaseService, DataBaseService>();
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();


            return services;
        }
    }
}
