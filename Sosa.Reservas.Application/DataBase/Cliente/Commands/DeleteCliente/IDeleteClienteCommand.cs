using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente
{
    public interface IDeleteClienteCommand
    {
        Task<bool> Execute(int id);
    }
}
