using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario
{
    public interface ICreateUsuarioCommand
    {
        Task<CreateUsuarioModel> Execute(CreateUsuarioModel model);
    }
}
