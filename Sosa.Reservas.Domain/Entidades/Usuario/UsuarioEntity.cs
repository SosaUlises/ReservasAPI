using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sosa.Reservas.Domain.Entidades.Reserva;

namespace Sosa.Reservas.Domain.Entidades.Usuario
{
    public class UsuarioEntity
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public ICollection<ReservaEntity> Reservas { get; set; }

    }
}
