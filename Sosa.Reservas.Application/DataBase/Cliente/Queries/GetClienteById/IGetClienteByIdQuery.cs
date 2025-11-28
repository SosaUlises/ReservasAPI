

using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById
{
    public interface IGetClienteByIdQuery
    {
        Task<BaseResponseModel> Execute(int clienteId, int userId);
    }
}
