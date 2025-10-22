using Microsoft.AspNetCore.Identity;
using Sosa.Reservas.Domain.Entidades.Reserva;

namespace Sosa.Reservas.Domain.Entidades.Usuario
{
    public class UsuarioEntity : IdentityUser<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public ICollection<ReservaEntity> Reservas { get; set; }

    }
}
