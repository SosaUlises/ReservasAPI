using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetHabitacionesByHotel
{
    public class GetHabitacionesByHotelQuery : IGetHabitacionesByHotelQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetHabitacionesByHotelQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(int hotelId)
        {
            var existeHotel = await _dataBaseService.Hoteles
                .AnyAsync(x => x.Id == hotelId);

            if (!existeHotel)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    "No pudimos encontrar este hotel");
            }

            var habitaciones = await _dataBaseService.Habitaciones
                .Where(x => x.HotelId == hotelId)
                .ToListAsync();

            var model = _mapper.Map<List<GetHabitacionesByHotelModel>>(habitaciones);

            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                model);
        }
    }
}
