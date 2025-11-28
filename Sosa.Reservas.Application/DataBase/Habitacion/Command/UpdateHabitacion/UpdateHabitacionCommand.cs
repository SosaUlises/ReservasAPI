using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion
{
    public class UpdateHabitacionCommand : IUpdateHabitacionCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateHabitacionCommand(
            IDataBaseService dataBaseService,
            IMapper mapper
            )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(UpdateHabitacionModel model)
        {

            var hotel = await _dataBaseService.Hoteles.FirstOrDefaultAsync(x => x.Id == model.HotelId);

            if (hotel == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Hotel no encontrado");

            var habitacion = await _dataBaseService.Habitaciones.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (habitacion == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Habitacion no encontrada");

            try
            {
                _mapper.Map(model, habitacion);
                _dataBaseService.Habitaciones.Update(habitacion);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                return ResponseApiService.Response(
                            StatusCodes.Status400BadRequest);
            }

            return ResponseApiService.Response(
                          StatusCodes.Status200OK,
                        "Habitacion modificada correctamente");
        }
    }
}
