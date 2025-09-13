using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni
{
    public class GetReservasByDniModel
    {
        public DateTime RegistrarFecha { get; set; }
        public string CodigoReserva { get; set; }
        public string TipoReserva { get; set; }

    }
}
