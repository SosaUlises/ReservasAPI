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
        private readonly ISendEmailConfirmacionReservaCommand _sendEmailConfirmacionReservaCommand;

        public CreateReservaCommand(
            IDataBaseService dataBaseService,
            ISendEmailConfirmacionReservaCommand sendEmailConfirmacionReservaCommand)
        {
            _dataBaseService = dataBaseService;
            _sendEmailConfirmacionReservaCommand = sendEmailConfirmacionReservaCommand;
        }

        public async Task<BaseResponseModel> Execute(CreateReservaModel model, int userId)
        {

            // Validación de fechas
            if (model.CheckIn >= model.CheckOut)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "Las fechas de CheckIn y CheckOut no son válidas");
            }


            // Obtener cliente del token
            var cliente = await _dataBaseService.Clientes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(x => x.UsuarioId == userId);

            if (cliente == null)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    "Cliente no encontrado");
            }

            // Obtener habitacion
            var habitacion = await _dataBaseService.Habitaciones
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(x => x.Id == model.HabitacionId);

            if (habitacion == null)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    "Habitación no encontrada");
            }

            if (!habitacion.Activa)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "La habitación no está habilitada");
            }

            // Validar fechas existentes de reservas
            var hayReserva = await _dataBaseService.Reservas.AnyAsync(r =>
                r.HabitacionId == model.HabitacionId &&
                model.CheckIn < r.CheckOut &&
                model.CheckOut > r.CheckIn
            );

            if (hayReserva)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status409Conflict,
                    "La habitación ya está reservada en esas fechas");
            }

            // Calculo de noches y precio total
            var noches = (model.CheckOut - model.CheckIn).Days;

            if (noches <= 0)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    "Las fechas no son válidas");
            }

            var precioTotal = habitacion.PrecioPorNoche * noches;

            var checkInUtc = DateTime.SpecifyKind(model.CheckIn, DateTimeKind.Utc);
            var checkOutUtc = DateTime.SpecifyKind(model.CheckOut, DateTimeKind.Utc);

            // Crear entidad
            var entity = new ReservaEntity
            {
                CodigoReserva = GenerarCodigoReserva(),
                CheckIn = checkInUtc,
                CheckOut = checkOutUtc,
                CantidadPersonas = model.CantidadPersonas,
                HabitacionId = model.HabitacionId,
                ClienteId = cliente.Id,
                PrecioTotal = precioTotal
            };

            // Guardar
            await _dataBaseService.Reservas.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            // Enviar email
           await _sendEmailConfirmacionReservaCommand.Execute(entity, cliente, habitacion);
            return ResponseApiService.Response(StatusCodes.Status201Created,
                "Reserva creada correctamente");
        }

        private string GenerarCodigoReserva()
        {
            return $"RSV-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
    }

}
