using Sosa.Reservas.Domain.Entidades.Habitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Domain.Entidades.Hotel
{
    public class HotelEntity
    {
        public int Id { get;  set; }
        public string Nombre { get;  set; }
        public string Ciudad { get;  set; } 
        public string Pais { get;  set; }
        public int Estrellas { get;  set; }
        public ICollection<HabitacionEntity> Habitaciones { get;  set; }
    }
}
