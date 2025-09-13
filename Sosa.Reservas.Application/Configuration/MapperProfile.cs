using AutoMapper;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;
using Sosa.Reservas.Domain.Entidades.Cliente;
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


            #endregion
        }
    }
}
