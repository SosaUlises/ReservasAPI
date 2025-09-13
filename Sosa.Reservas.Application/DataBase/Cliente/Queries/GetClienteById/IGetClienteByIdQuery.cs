

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById
{
    public interface IGetClienteByIdQuery
    {
        Task<GetClienteByIdModel> Execute(int id);
    }
}
