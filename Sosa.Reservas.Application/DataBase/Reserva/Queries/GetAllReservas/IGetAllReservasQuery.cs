namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas
{
    public interface IGetAllReservasQuery
    {
        Task<List<GetAllReservasModel>> Execute();
    }
}
