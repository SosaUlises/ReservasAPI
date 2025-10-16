using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Login.Queries;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario; 
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features; 


namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))] 
    public class AuthController : ControllerBase
    {

        [AllowAnonymous] 
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginModel model,
            [FromServices] ILoginQuery loginQuery,
            [FromServices] IValidator<LoginModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var token = await loginQuery.Execute(model);

            if (string.IsNullOrEmpty(token))
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    ResponseApiService.Response(StatusCodes.Status401Unauthorized, null, "Usuario o contraseña inválidos."));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, new { token }));
        }

    }
}