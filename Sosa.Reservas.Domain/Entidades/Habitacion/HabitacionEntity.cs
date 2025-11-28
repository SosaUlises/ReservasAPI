using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Entidades.Reserva;

namespace Sosa.Reservas.Domain.Entidades.Habitacion
{
    public class HabitacionEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public HotelEntity Hotel { get; set; }
        public string Numero { get; set; } // Ej: "104", "201B"
        public string Tipo { get; set; } // Ej: "Simple", "Doble", "Suite"
        public decimal PrecioPorNoche { get; set; }
        public int CapacidadPersonas { get; set; }
        public bool Activa { get; set; } = true;

        public ICollection<ReservaEntity> Reservas { get; set; }
    }
}
