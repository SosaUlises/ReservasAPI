using AutoMapper;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetHotelesByPais;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
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

            // Clientes
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
            #endregion

            #region Reserva
            CreateMap<ReservaEntity, CreateReservaModel>().ReverseMap();
            /*
                        CreateMap<ReservaEntity, GetAllReservasModel>()
                            .ForMember(dest => dest.ClienteFullName,
                                opt => opt.MapFrom(src => src.Cliente.FullName))
                            .ForMember(dest => dest.ClienteDni,
                                opt => opt.MapFrom(src => src.Cliente.DNI));


                        CreateMap<ReservaEntity, GetReservasByDniModel>().ReverseMap();

                        CreateMap<ReservaEntity, GetReservasByTipoModel>()
                            .ForMember(dest => dest.ClienteFullName,
                                opt => opt.MapFrom(src => src.Cliente.FullName))
                            .ForMember(dest => dest.ClienteDni,
                                opt => opt.MapFrom(src => src.Cliente.DNI));
            */

            #endregion
        }
    }
}
