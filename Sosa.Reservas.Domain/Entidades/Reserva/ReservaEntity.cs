using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Domain.Entidades.Reserva
{
    public class ReservaEntity 
    {
        public int ReservaId {  get; set; }
        public DateTime RegistrarFecha { get; set; }
        public string CodigoReserva { get; set; }
        public string TipoReserva { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }
        public ClienteEntity Cliente { get; set; }
    }
}
