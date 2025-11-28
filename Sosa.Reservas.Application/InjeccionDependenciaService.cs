using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sosa.Reservas.Application.Configuration;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.DeleteHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.DeleteHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetHotelesByPais;
using Sosa.Reservas.Application.DataBase.Login.Command.Login;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.Validators.Cliente;
using Sosa.Reservas.Application.Validators.Habitacion;
using Sosa.Reservas.Application.Validators.Hotel;
using Sosa.Reservas.Application.Validators.Login;
using Sosa.Reservas.Application.Validators.Reserva;

namespace Sosa.Reservas.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            #region Usuarios
            services.AddTransient<IGetAllUsuarioQuery, GetAllUsuarioQuery>();
            services.AddTransient<IGetUsuarioByIdQuery, GetUsuarioByIdQuery>();
           
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
            #endregion

            #region Hotel
            services.AddTransient<ICreateHotelCommand, CreateHotelCommand>();
            services.AddTransient<IUpdateHotelCommand, UpdateHotelCommand>();
            services.AddTransient<IDeleteHotelCommand, DeleteHotelCommand>();
            services.AddTransient<IGetAllHotelesQuery, GetAllHotelesQuery>();
            services.AddTransient<IGetHotelesByPaisQuery, GetHotelesByPaisQuery>();
            #endregion

            #region Habitacion
            services.AddTransient<ICreateHabitacionCommand, CreateHabitacionCommand>();
            services.AddTransient<IUpdateHabitacionCommand, UpdateHabitacionCommand>();
            services.AddTransient<IDeleteHabitacionCommand, DeleteHabitacionCommand>();
            #endregion

            #region Validators
            services.AddScoped<IValidator<CreateClienteModel>, CreateClienteValidator>();
            services.AddScoped<IValidator<CreateHotelModel>, CreateHotelValidator>();
            services.AddScoped<IValidator<UpdateClienteModel>, UpdateClienteValidator>();
            services.AddScoped<IValidator<CreateReservaModel>, CreateReservaValidator>();
            services.AddScoped<IValidator<LoginModel>, LoginValidator>();
            services.AddScoped<IValidator<CreateHabitacionModel>, CreateHabitacionValidator>();
            services.AddScoped<IValidator<UpdateHabitacionModel>, UpdateHabitacionValidator>();
            #endregion

            return services;
        }
    }
}