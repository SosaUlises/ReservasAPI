using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel
{
    public interface ICreateHotelCommand
    {
        Task<BaseResponseModel> Execute(CreateHotelModel model);
    }
}
