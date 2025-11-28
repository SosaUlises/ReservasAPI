using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni
{
    public interface IGetClienteByDniQuery
    {
        Task<BaseResponseModel> Execute(string dni);
    }
}
