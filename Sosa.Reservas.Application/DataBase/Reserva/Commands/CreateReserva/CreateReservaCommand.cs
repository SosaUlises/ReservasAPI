using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase.Email;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Models;
using static Sosa.Reservas.Application.DataBase.Email.SendEmailConfirmacionReservaCommand;


namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public class CreateReservaCommand : ICreateReservaCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ISendEmailConfirmacionReservaCommand _sendEmailConfirmacionReservaCommand;
        public CreateReservaCommand(
            IDataBaseService dataBaseService,
            IMapper mapper,
            ISendEmailConfirmacionReservaCommand sendEmailConfirmacionReservaCommand)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _sendEmailConfirmacionReservaCommand = sendEmailConfirmacionReservaCommand;
        }

        public async Task<BaseResponseModel> Execute(CreateReservaModel model)
        {
            // Validacion de fechas
            if (model.CheckIn >= model.CheckOut)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "Las fechas de CheckIn y CheckOut no son validas");
            }

            var cliente = await _dataBaseService.Clientes
                .FirstOrDefaultAsync(x => x.Id == model.ClienteId);

            if (cliente == null)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    "Cliente no encontrado");
            }

            var habitacion = await _dataBaseService.Habitaciones
                .FirstOrDefaultAsync(x => x.Id == model.HabitacionId);

            if (habitacion == null)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    "Habitacion no encontrada");
            }

            if (!habitacion.Activa)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "La habitacion no esta habilitada");
            }

            // Chequear fechas
            var hayReserva = await _dataBaseService.Reservas.AnyAsync(r =>
                r.HabitacionId == model.HabitacionId &&
                model.CheckIn < r.CheckOut &&
                model.CheckOut > r.CheckIn
            );

            if (hayReserva)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status409Conflict,
                    "La habitacion ya esta reservada en esas fechas");
            }

            var noches = (model.CheckOut - model.CheckIn).Days;

            if (noches <= 0)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "Las fechas no son válidas");
            }

            var precioTotal = habitacion.PrecioPorNoche * noches;

            var entity = _mapper.Map<ReservaEntity>(model);
            entity.PrecioTotal = precioTotal;

            await _dataBaseService.Reservas.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            await _sendEmailConfirmacionReservaCommand.Execute(entity, cliente, habitacion);

            return ResponseApiService.Response(
                StatusCodes.Status201Created,
                "Reserva exitosa"
            );
        }
    }

}
