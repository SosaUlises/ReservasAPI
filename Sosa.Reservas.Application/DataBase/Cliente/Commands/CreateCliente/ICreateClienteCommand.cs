using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente
{
    public interface ICreateClienteCommand
    {
        Task<CreateClienteModel> Execute(CreateClienteModel model);
    }
}
