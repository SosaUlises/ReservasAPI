using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword
{
    public class UpdateUsuarioPasswordModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
