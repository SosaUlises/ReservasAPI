namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas
{
    public class GetAllReservasModel
    {
        public int ReservaId { get; set; }
        public DateTime RegistrarFecha { get; set; }
        public string CodigoReserva { get; set; }
        public string TipoReserva { get; set; }
        public string ClienteDni { get; set; }
        public string ClienteFullName { get; set; }
    }
}
