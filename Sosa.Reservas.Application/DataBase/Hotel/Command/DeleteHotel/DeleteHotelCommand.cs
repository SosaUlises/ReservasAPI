using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Hotel.Command.DeleteHotel
{
    public class DeleteHotelCommand : IDeleteHotelCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteHotelCommand(
            IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<BaseResponseModel> Execute(int hotelId)
        {
            var hotel = await _dataBaseService.Hoteles.FirstOrDefaultAsync(x => x.Id == hotelId);

            if (hotel == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Hotel no encontrado");

            _dataBaseService.Hoteles.Remove(hotel);
            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                "Hotel borrado correctamente");

        }
    }
}
