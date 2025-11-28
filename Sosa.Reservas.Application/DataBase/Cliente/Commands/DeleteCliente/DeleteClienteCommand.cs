using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Domain.Models;


namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IDeleteClienteCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly UserManager<UsuarioEntity> _userManager;

        public DeleteClienteCommand(
            IDataBaseService dataBaseService,
            UserManager<UsuarioEntity> userManager)
        {
            _dataBaseService = dataBaseService;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(int clienteId)
        {
            var cliente = await _dataBaseService.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId);

            if (cliente == null)
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound,
                    "Cliente no encontrado");
            }

            var user = await _userManager.FindByIdAsync(cliente.UsuarioId.ToString());

            if (user == null)
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound,
                    "Usuario no encontrado");
            }

            var resultUsuario = await _userManager.DeleteAsync(user);

            if (!resultUsuario.Succeeded)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                   "Error al eliminar el usuario");
            }

            try
            {
                _dataBaseService.Clientes.Remove(cliente);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest);
            }


            return ResponseApiService.Response(StatusCodes.Status200OK,
                  "Cliente eliminado correctamente");
        }
    }
}
