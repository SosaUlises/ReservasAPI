using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente
{
    public interface IDeleteClienteCommand
    {
        Task<BaseResponseModel> Execute(int clienteId);
    }
}
