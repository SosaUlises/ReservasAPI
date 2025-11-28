using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Command.DeleteHabitacion
{
    public class DeleteHabitacionCommand : IDeleteHabitacionCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteHabitacionCommand(
            IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<BaseResponseModel> Execute(int habitacionId)
        {
            var habitacion = await _dataBaseService.Habitaciones.FirstOrDefaultAsync(x => x.Id == habitacionId);

            if (habitacion == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Habitacion no encontrada");

            _dataBaseService.Habitaciones.Remove(habitacion);
            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                "Habitacion borrada correctamente");

        }
    }
}
