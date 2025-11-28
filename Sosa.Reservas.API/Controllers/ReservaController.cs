using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservasByCliente;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features;
using System.Security.Claims;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/reserva")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ReservaController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateReservaModel model,
            [FromServices] ICreateReservaCommand createReservaCommand,
            [FromServices] IValidator<CreateReservaModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createReservaCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllReservasQuery getAllReservasQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageNumber = 10;
            if (pageSize > 100) pageNumber = 100;

            var data = await getAllReservasQuery.Execute(pageNumber, pageSize);

            if (!data.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpGet("getAllByCliente/{clienteId}")]
        public async Task<IActionResult> GetAllByCliente(
            int clienteId,
           [FromServices] IGetAllReservasByClienteQuery getAllReservasByClienteQuery)
        {
            if (clienteId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                       ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await getAllReservasByClienteQuery.Execute(clienteId, int.Parse(userId));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }



    }
}
