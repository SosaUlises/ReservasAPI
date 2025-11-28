using AutoMapper;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetAllHabitaciones;
using Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetHabitacionesByHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetHotelesByPais;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservasByCliente;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Habitacion;
using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Usuario
            CreateMap<UsuarioEntity, GetAllUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetUsuarioByIdModel>().ReverseMap();
            #endregion

            #region Cliente

            CreateMap<CreateClienteModel, UsuarioEntity>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateClienteModel, ClienteEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioId, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<UsuarioEntity, UpdateClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, UpdateClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, GetAllClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, GetClienteByIdModel>().ReverseMap();
            CreateMap<ClienteEntity, GetClienteByDniModel>().ReverseMap();
            #endregion

            #region Hotel
            CreateMap<HotelEntity, CreateHotelModel>().ReverseMap();
            CreateMap<HotelEntity, UpdateHotelModel>().ReverseMap();
            CreateMap<HotelEntity, GetAllHotelesModel>().ReverseMap();
            CreateMap<HotelEntity, GetHotelesByPaisModel>().ReverseMap();
            #endregion

            #region Habitacion
            CreateMap<HabitacionEntity, CreateHabitacionModel>().ReverseMap();
            CreateMap<HabitacionEntity, UpdateHabitacionModel>().ReverseMap();
            CreateMap<HabitacionEntity, GetAllHabitacionesModel>().ReverseMap();
            CreateMap<HabitacionEntity, GetHabitacionesByHotelModel>().ReverseMap();
            #endregion

            #region Reserva

            CreateMap<CreateReservaModel, ReservaEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.PrecioTotal, opt => opt.Ignore()) 
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Habitacion, opt => opt.Ignore());

            CreateMap<ReservaEntity, GetAllReservasModel>().ReverseMap();
            CreateMap<ReservaEntity, GetAllReservasByClienteModel>().ReverseMap();

            #endregion
        }
    }
}
