using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Interfaces;
using Sosa.Reservas.Persistence.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            return services;
        }
    }
}
