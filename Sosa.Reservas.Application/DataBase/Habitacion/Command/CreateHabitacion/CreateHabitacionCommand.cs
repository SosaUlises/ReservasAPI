using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Habitacion;
using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion
{
    public class CreateHabitacionCommand : ICreateHabitacionCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateHabitacionCommand(
            IDataBaseService dataBaseService,
            IMapper mapper
            )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(CreateHabitacionModel model)
        {
            var hotel = await _dataBaseService.Hoteles.FirstOrDefaultAsync(x => x.Id == model.HotelId);

            if (hotel == null)
            {
                return ResponseApiService.Response(
                                          StatusCodes.Status404NotFound,
                                          "Hotel no encontrado");
            }

            var habitacion = _mapper.Map<HabitacionEntity>(model);

            try
            {
                await _dataBaseService.Habitaciones.AddAsync(habitacion);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                return ResponseApiService.Response(
                            StatusCodes.Status400BadRequest);
            }

            return ResponseApiService.Response(
                          StatusCodes.Status201Created,
                        "Habitacion creada correctamente");
        }
    }
}
