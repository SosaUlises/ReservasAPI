using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById
{
    public class GetClienteByIdModel
    {
        // User Identity
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }

        // Cliente

        public int Id { get; set; }
        public string Telefono { get; set; }
    }
}
