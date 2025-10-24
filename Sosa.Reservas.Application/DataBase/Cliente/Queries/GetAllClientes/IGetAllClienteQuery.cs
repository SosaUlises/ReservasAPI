
using X.PagedList;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes
{
    public interface IGetAllClienteQuery
    {
        Task<IPagedList<GetAllClienteModel>> Execute(int pageNumber, int pageSize);
    }
}
