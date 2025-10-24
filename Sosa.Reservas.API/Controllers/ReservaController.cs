using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni;
using Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByTipo;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/reserva")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ReservaController : ControllerBase
    {
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
                ResponseApiService.Response(StatusCodes.Status201Created,data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllReservasQuery getAllReservasQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {

            if(pageNumber <= 0) pageNumber = 1;
            if(pageSize <= 0) pageNumber = 10;
            if(pageSize > 100) pageNumber = 100;

            var data = await getAllReservasQuery.Execute(pageNumber,pageSize);

            if(!data.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("getByDni/{dni}")]
        public async Task<IActionResult> GetByDni(
            string dni,
           [FromServices] IGetReservasByDniQuery getReservasByDniQuery)
        {
            if(dni == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                       ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getReservasByDniQuery.Execute(dni);

            if(data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }

        [HttpGet("getByTipo/{tipo}")]
        public async Task<IActionResult> GetByTipo(
            string tipo,
            [FromServices] IGetReservasByTipoQuery getReservasByTipoQuery)
        {
            if(tipo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                  ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getReservasByTipoQuery.Execute(tipo);

            if(data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }
        
    }
}
