using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetHabitacionesByHotel
{
    public interface IGetHabitacionesByHotelQuery
    {
        Task<BaseResponseModel> Execute(int hotelId);
    }
}
