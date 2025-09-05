using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Domain.Entidades.Reserva
{
    public class Reserva
    {
        private int ReservaId {  get; set; }    
        private DateTime RegistrarFecha { get; set; }
        private string CodigoReserva { get; set; }
        private string TipoReserva { get; set; }
        private int ClienteId { get; set; }
        private int UsuarioId { get; set; }
    }
}
