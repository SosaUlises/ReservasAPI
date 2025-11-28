using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Command.DeleteHotel
{
    public interface IDeleteHotelCommand
    {
        Task<BaseResponseModel> Execute(int hotelId);
    }
}
