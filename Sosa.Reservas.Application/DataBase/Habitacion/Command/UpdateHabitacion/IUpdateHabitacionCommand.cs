using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion
{
    public interface IUpdateHabitacionCommand
    {
        Task<BaseResponseModel> Execute(UpdateHabitacionModel model);
    }
}
