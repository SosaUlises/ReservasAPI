
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public interface ICreateReservaCommand
    {
        Task<BaseResponseModel> Execute(CreateReservaModel model);
    }
}
