using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.External.SendGridEmail;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models.SendGridEmail;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody]SendGridEmailRequestModel model,
            [FromServices] ISendGridEmailService sendGridEmailService
            )
        {
            var data = await sendGridEmailService.Execute(model);

            if(!data)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseApiService.Response(StatusCodes.Status500InternalServerError));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    ResponseApiService.Response(StatusCodes.Status200OK));
            }
        
        }
    }
}
