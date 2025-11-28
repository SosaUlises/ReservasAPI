using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Habitacion;
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
        public int Id { get; set; }
        public string CodigoReserva { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal PrecioTotal { get; set; }
        public int CantidadPersonas { get; set; }

        // Relaciones
        public int ClienteId { get; set; }
        public ClienteEntity Cliente { get; set; }
        public int HabitacionId { get; set; } 
        public HabitacionEntity Habitacion { get; set; }
    }
}
