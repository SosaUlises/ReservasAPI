using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.External.GetTokenJWT;
using Sosa.Reservas.Application.Features;

namespace Sosa.Reservas.API.Controllers
{
    [Authorize]
    [Route("api/v1/usuario")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UsuarioController : ControllerBase
    {

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUsuarioModel model,
            [FromServices] IUpdateUsuarioCommand updateUsuarioCommand,
            [FromServices] IValidator<UpdateUsuarioModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }


            var data = await updateUsuarioCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
         [FromBody] UpdateUsuarioPasswordModel model,
         [FromServices] IUpdateUsuarioPasswordCommand updateUsuarioPasswordCommand,
         [FromServices] IValidator<UpdateUsuarioPasswordModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await updateUsuarioPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(int userId,
        [FromServices] IDeleteUsuarioCommand deleteUsuarioCommand)
        {
            if (userId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                 ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await deleteUsuarioCommand.Execute(userId);

            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUsuarioQuery getAllUsuarioQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {
            // Limitamos
            if(pageNumber <= 0) pageNumber = 1;
            if(pageSize <= 0) pageSize = 10;
            if(pageSize > 100) pageSize = 100;

            var data = await getAllUsuarioQuery.Execute(pageNumber,pageSize);


            if (!data.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }

            return StatusCode(StatusCodes.Status200OK,
                       ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("getById/{userId}")]
        public async Task<IActionResult> GetById(int userId, [FromServices] IGetUsuarioByIdQuery getUsuarioByIdQuery)
        {

            if (userId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                        ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getUsuarioByIdQuery.Execute(userId);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                       ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK,
                       ResponseApiService.Response(StatusCodes.Status200OK, data));
        }



    }
}
