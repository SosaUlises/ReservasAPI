using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.External.GetTokenJWT
{
    public interface IGetTokenJWTService
    {
        string Execute(string userId, string role, UsuarioEntity usuario);
    }
}
