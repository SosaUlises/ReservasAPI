using AutoMapper;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UsuarioEntity, CreateUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, UpdateUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetAllUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetUsuarioByIdModel>().ReverseMap();
            CreateMap<UsuarioEntity, GetUsuarioByUserNameAndPasswordModel>().ReverseMap();
        }
    }
}
