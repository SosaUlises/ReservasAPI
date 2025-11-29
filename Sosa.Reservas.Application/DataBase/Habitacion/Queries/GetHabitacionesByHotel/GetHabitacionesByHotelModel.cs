using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetHabitacionesByHotel
{
    public class GetHabitacionesByHotelModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public int CapacidadPersonas { get; set; }
    }
}
