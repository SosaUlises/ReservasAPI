using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Domain.Models;
using System.Security.Claims;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IUpdateClienteCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<UsuarioEntity> _userManager;

        public UpdateClienteCommand(
            IDataBaseService dataBaseService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<UsuarioEntity> userManager)
        {
            _dataBaseService = dataBaseService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(UpdateClienteModel model, int userId)
        {
            // Obtener rol del usuario logueado
            var httpUser = _httpContextAccessor.HttpContext.User;
            var roles = httpUser.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
            bool esAdmin = roles.Contains("Administrador");

            var clienteLog = await _dataBaseService.Clientes
                                .FirstOrDefaultAsync(c => c.UsuarioId == userId);

            if (clienteLog == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Cliente no encontrado");


            if (!esAdmin && clienteLog.UsuarioId != userId)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status403Forbidden,
                    "No puedes modificar a otro usuario");
            }


            var usuario = await _userManager.FindByIdAsync(userId.ToString());
            if (usuario == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Usuario no encontrado");

            var existeEmail = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Email == model.Email && x.Id != usuario.Id);

            if (existeEmail != null)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    $"Ya existe un usuario con el email {model.Email}");

            var existeDni = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Dni == model.Dni && x.Id != usuario.Id);

            if (existeDni != null)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    $"Ya existe un usuario con el DNI {model.Dni}");


            usuario.Nombre = model.Nombre;
            usuario.Apellido = model.Apellido;
            usuario.Email = model.Email;
            usuario.UserName = model.Email;
            usuario.Dni = model.Dni;

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                await _userManager.ResetPasswordAsync(usuario, token, model.Password);
            }

            var result = await _userManager.UpdateAsync(usuario);
            if (!result.Succeeded)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    "Error al modificar el usuario");


            clienteLog.Telefono = model.Telefono;

            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status200OK,
                "Cliente actualizado correctamente");
        }
    }

}
