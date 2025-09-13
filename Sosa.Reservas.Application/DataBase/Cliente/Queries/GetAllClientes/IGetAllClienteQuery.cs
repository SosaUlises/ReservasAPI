
namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes
{
    public interface IGetAllClienteQuery
    {
        Task<List<GetAllClienteModel>> Execute();
    }
}
