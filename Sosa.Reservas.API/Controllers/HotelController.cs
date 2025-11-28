using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.DeleteHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/hotel")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class HotelController : Controller
    {

        [Authorize(Roles = "Administrador")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateHotelModel model,
            [FromServices] ICreateHotelCommand createHotelCommand,
            [FromServices] IValidator<CreateHotelModel> validator
            )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createHotelCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(
           [FromBody] UpdateHotelModel model,
           [FromServices] IUpdateHotelCommand updateHotelCommand,
           [FromServices] IValidator<UpdateHotelModel> validator
           )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await updateHotelCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("delete/{hotelId}")]
        public async Task<IActionResult> Delete(
            int hotelId,
           [FromServices] IDeleteHotelCommand deleteHotelCommand
           )
        {

            if (hotelId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await deleteHotelCommand.Execute(hotelId);
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllHotelesQuery getAllHotelesQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var data = await getAllHotelesQuery.Execute(pageNumber, pageSize);

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
