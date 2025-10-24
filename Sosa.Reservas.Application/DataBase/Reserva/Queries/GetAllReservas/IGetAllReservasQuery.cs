using X.PagedList;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas
{
    public interface IGetAllReservasQuery
    {
        Task<IPagedList<GetAllReservasModel>> Execute(int pageNumber, int pageSize);
    }
}
