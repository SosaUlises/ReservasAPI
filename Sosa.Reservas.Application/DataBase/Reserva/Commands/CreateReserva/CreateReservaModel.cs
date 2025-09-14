

namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public class CreateReservaModel
    {
        public string CodigoReserva { get; set; }
        public string TipoReserva { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
