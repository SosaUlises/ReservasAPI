using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;

namespace Sosa.Reservas.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}