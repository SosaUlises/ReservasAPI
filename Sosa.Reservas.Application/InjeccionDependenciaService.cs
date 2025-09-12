using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;

namespace Sosa.Reservas.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddTransient<ICreateUsuarioCommand, CreateUsuarioCommand>();

            return services;
        }
    }
}