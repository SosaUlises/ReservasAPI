using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservasByCliente
{
    public class GetAllReservasByClienteModel
    {
        public string CodigoReserva { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CantidadPersonas { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
