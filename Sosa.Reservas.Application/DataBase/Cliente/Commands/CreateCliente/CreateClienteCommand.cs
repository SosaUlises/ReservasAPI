using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente
{
    public class CreateClienteCommand : ICreateClienteCommand
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateClienteCommand(
            IDataBaseService dataBaseService,
            IMapper mapper,
          UserManager<UsuarioEntity> userManager)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(CreateClienteModel model)
        {
            var existeEmail = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            var existeDni = await _userManager.Users.FirstOrDefaultAsync(x => x.Dni == model.Dni);

            if (existeEmail != null)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    $"Ya existe un usuario con el email {model.Email}");

            if (existeDni != null)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    $"Ya existe un usuario con el DNI {model.Dni}");

            // Usuario
            var usuario = _mapper.Map<UsuarioEntity>(model);
            usuario.UserName = model.Email;

            var result = await _userManager.CreateAsync(usuario, model.Password);

            if (!result.Succeeded)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    result.Errors, "Error al crear el usuario");

            var rolResult = await _userManager.AddToRoleAsync(usuario, "Cliente");
            if (!rolResult.Succeeded)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,
                    rolResult.Errors, "Error al asignar el rol al usuario");

            // Cliente
            var cliente = _mapper.Map<ClienteEntity>(model);
            cliente.UsuarioId = usuario.Id;

            try
            {
                await _dataBaseService.Clientes.AddAsync(cliente);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                await _userManager.DeleteAsync(usuario);
                throw;
            }

            return ResponseApiService.Response(
                          StatusCodes.Status201Created,
                          new
                          {
                              UsuarioId = usuario.Id,
                              cliente.Id,
                              usuario.Email,
                              usuario.Nombre,
                              usuario.Apellido
                          },
                          "Cliente creado correctamente"
                      );
        }
    }
}
