using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente
{
    public class UpdateClienteModel
    {
        // User Identity
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Rol { get; set; }

        // Cliente
        public int Id { get; set; }
        public string Telefono { get; set; }
    }
}
