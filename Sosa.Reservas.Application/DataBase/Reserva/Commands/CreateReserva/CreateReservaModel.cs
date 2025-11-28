
namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public class CreateReservaModel
    {
        public string CodigoReserva { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CantidadPersonas { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
    }
}
