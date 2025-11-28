using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.DeleteHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetAllHabitaciones;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/habitacion")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class HabitacionController : Controller
    {

        [Authorize(Roles = "Administrador")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateHabitacionModel model,
            [FromServices] ICreateHabitacionCommand createHabitacionCommand,
            [FromServices] IValidator<CreateHabitacionModel> validator
            )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createHabitacionCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(
           [FromBody] UpdateHabitacionModel model,
           [FromServices] IUpdateHabitacionCommand updateHabitacionCommand,
           [FromServices] IValidator<UpdateHabitacionModel> validator
           )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await updateHabitacionCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("delete/{habitacionId}")]
        public async Task<IActionResult> Delete(
            int habitacionId,
           [FromServices] IDeleteHabitacionCommand deleteHabitacionCommand
           )
        {

            if (habitacionId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await deleteHabitacionCommand.Execute(habitacionId);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [AllowAnonymous]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
           [FromServices] IGetAllHabitacionesQuery getAllHabitacionesQuery,
           [FromQuery] int pageNumber = 1,
           [FromQuery] int pageSize = 5
           )
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var data = await getAllHabitacionesQuery.Execute(pageNumber, pageSize);

            if (!data.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }

            return StatusCode(StatusCodes.Status200OK,
                       ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

    }
}
