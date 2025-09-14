using AutoMapper;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByTipo;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Usuario
            CreateMap<UsuarioEntity, CreateUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, UpdateUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetAllUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetUsuarioByIdModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetUsuarioByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Cliente
            CreateMap<ClienteEntity, CreateClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, UpdateClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, GetAllClienteModel>().ReverseMap();
            CreateMap<ClienteEntity, GetClienteByIdModel>().ReverseMap();
            CreateMap<ClienteEntity, GetClienteByDniModel>().ReverseMap();
            #endregion

            #region Reserva
            CreateMap<ReservaEntity, CreateReservaModel>().ReverseMap();

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


            #endregion
        }
    }
}
