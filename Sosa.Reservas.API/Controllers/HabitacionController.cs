using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
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

    }
}
