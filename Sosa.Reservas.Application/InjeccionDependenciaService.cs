using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
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

            #region Usuarios
            services.AddTransient<ICreateUsuarioCommand, CreateUsuarioCommand>();
            services.AddTransient<IUpdateUsuarioCommand, UpdateUsuarioCommand>();
            services.AddTransient<IDeleteUsuarioCommand, DeleteUsuarioCommand>();
            services.AddTransient<IUpdateUsuarioPasswordCommand, UpdateUsuarioPasswordCommand>();
            services.AddTransient<IGetAllUsuarioQuery, GetAllUsuarioQuery>();
            services.AddTransient<IGetUsuarioByIdQuery, GetUsuarioByIdQuery>();
            services.AddTransient<IGetUsuarioByUserNameAndPasswordQuery, GetUsuarioByUserNameAndPasswordQuery>();
            #endregion

            #region Clientes
            services.AddTransient<ICreateClienteCommand, CreateClienteCommand>();
            services.AddTransient<IUpdateClienteCommand, UpdateClienteCommand>();
            services.AddTransient<IDeleteClienteCommand, DeleteClienteCommand>();

            #endregion


            return services;
        }
    }
}