using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Sosa.Reservas.API
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sosa Reservas",
                    Description = "Administracion de APIs para Reservas App"
                });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}
