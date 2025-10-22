using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.DataBase.Login.Queries;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByTipo;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;
using Sosa.Reservas.Application.Validators.Cliente;
using Sosa.Reservas.Application.Validators.Login;
using Sosa.Reservas.Application.Validators.Reserva;
using Sosa.Reservas.Application.Validators.Usuario;

namespace Sosa.Reservas.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            #region Usuarios
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
            services.AddTransient<IGetAllClienteQuery, GetAllClienteQuery>();
            services.AddTransient<IGetClienteByIdQuery, GetClienteByIdQuery>();
            services.AddTransient<IGetClienteByDniQuery, GetClienteByDniQuery>();
            #endregion

            #region Reservas
            services.AddTransient<ICreateReservaCommand, CreateReservaCommand>();
            services.AddTransient<IGetAllReservasQuery, GetAllReservasQuery>();
            services.AddTransient<IGetReservasByDniQuery, GetReservasByDniQuery>();
            services.AddTransient<IGetReservasByTipoQuery, GetReservasByTipoQuery>();
            #endregion

            #region Validators

            services.AddScoped<IValidator<CreateUsuarioModel>, CreateUsuarioValidator>();
            services.AddScoped<IValidator<UpdateUsuarioModel>, UpdateUsuarioValidator>();
            services.AddScoped<IValidator<UpdateUsuarioPasswordModel>, UpdateUsuarioPasswordValidator>();
            services.AddScoped<IValidator<(string,string)>, GetUsuarioByUserNameAndPasswordValidator>();

            services.AddScoped<IValidator<CreateClienteModel>, CreateClienteValidator>();
            services.AddScoped<IValidator<UpdateClienteModel>, UpdateClienteValidator>();

            services.AddScoped<IValidator<CreateReservaModel>, CreateReservaValidator>();

            services.AddScoped<IValidator<LoginModel>, LoginValidator>();
            #endregion

            return services;
        }
    }
}