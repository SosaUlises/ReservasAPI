using Sosa.Reservas.Domain.Entidades.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion
{
    public class CreateHabitacionModel
    {
        public int HotelId { get; set; }
        public string Numero { get; set; } 
        public string Tipo { get; set; } // Ej: "Simple", "Doble", "Suite"
        public decimal PrecioPorNoche { get; set; }
        public int CapacidadPersonas { get; set; }
    }
}
