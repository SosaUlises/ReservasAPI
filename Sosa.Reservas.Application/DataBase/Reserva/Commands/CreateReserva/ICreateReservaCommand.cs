
namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public interface ICreateReservaCommand
    {
        Task<CreateReservaModel> Execute(CreateReservaModel model);
    }
}
