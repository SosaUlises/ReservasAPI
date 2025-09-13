

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni
{
    public interface IGetClienteByDniQuery
    {
        Task<GetClienteByDniModel> Execute(string dni);
    }
}
