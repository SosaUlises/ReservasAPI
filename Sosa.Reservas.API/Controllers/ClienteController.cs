using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById;
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.Features;
using System.ComponentModel.DataAnnotations;

namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/cliente")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ClienteController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateClienteModel model,
            [FromServices] ICreateClienteCommand createClienteCommand,
            [FromServices] IValidator<CreateClienteModel> validator
            )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createClienteCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, 
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateClienteModel model,
            [FromServices] IUpdateClienteCommand updateClienteCommand,
            [FromServices] IValidator<UpdateClienteModel> validator
            )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                      ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await updateClienteCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, 
                ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{clienteId}")]
        public async Task<IActionResult> Delete( 
            int clienteId, 
            [FromServices] IDeleteClienteCommand deleteClienteCommand)
        {
            if (clienteId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await deleteClienteCommand.Execute(clienteId);
            if (!data)
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


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllClienteQuery getAllClienteQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            // Limitamos
            if(pageNumber <= 0) pageNumber = 1; 
            if(pageSize <= 0) pageSize = 10; 
            if(pageSize > 100) pageSize = 100; 

            var data = await getAllClienteQuery.Execute(pageNumber,pageSize);

            if (data == null || !data.Any())
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

        [HttpGet("getById/{clienteId}")]
        public async Task<IActionResult> GetById(
            int clienteId,
            [FromServices] IGetClienteByIdQuery getClienteByIdQuery)
        {
            if(clienteId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                  ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getClienteByIdQuery.Execute(clienteId);

            if (data == null)
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

        [HttpGet("getByDni/{clienteDni}")]
        public async Task<IActionResult> GetByDni(
         string clienteDni,
         [FromServices] IGetClienteByDniQuery getClienteByDniQuery)
        {
            if (clienteDni == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                  ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getClienteByDniQuery.Execute(clienteDni);

            if (data == null)
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
