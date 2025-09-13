namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni
{
    public interface IGetReservasByDniQuery
    {
        Task<List<GetReservasByDniModel>> Execute(string dni);
    }
}
