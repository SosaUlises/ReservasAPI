using AutoMapper;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UsuarioEntity, CreateUsuarioModel>().ReverseMap();
            CreateMap<UsuarioEntity, UpdateUsuarioModel>().ReverseMap();
        }
    }
}
