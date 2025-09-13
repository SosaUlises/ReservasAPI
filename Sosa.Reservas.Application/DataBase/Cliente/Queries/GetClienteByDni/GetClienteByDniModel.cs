using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni
{
    public class GetClienteByDniModel
    {
        public int ClienteId { get; set; }
        public string FullName { get; set; }
        public string DNI { get; set; }
    }
}
