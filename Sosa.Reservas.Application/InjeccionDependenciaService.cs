using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;

namespace Sosa.Reservas.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddTransient<ICreateUsuarioCommand, CreateUsuarioCommand>();
            services.AddTransient<IUpdateUsuarioCommand, UpdateUsuarioCommand>();
            services.AddTransient<IDeleteUsuarioCommand, DeleteUsuarioCommand>();
            services.AddTransient<IUpdateUsuarioPasswordCommand, UpdateUsuarioPasswordCommand>();
            services.AddTransient<IGetAllUsuarioQuery, GetAllUsuarioQuery>();
            services.AddTransient<IGetUsuarioByIdQuery, GetUsuarioByIdQuery>();
            services.AddTransient<IGetUsuarioByUserNameAndPasswordQuery, GetUsuarioByUserNameAndPasswordQuery>();

            return services;
        }
    }
}