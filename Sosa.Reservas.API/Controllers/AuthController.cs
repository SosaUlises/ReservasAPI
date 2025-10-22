using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sosa.Reservas.Application.DataBase.Login.Queries;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario; 
using Sosa.Reservas.Application.Exception;
using Sosa.Reservas.Application.External.GetTokenJWT;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Usuario;


namespace Sosa.Reservas.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))] 
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly SignInManager<UsuarioEntity> _signInManager;
        private readonly IGetTokenJWTService _getTokenJwtService;

        public AuthController(
            UserManager<UsuarioEntity> userManager,
            SignInManager<UsuarioEntity> signInManager,
            IGetTokenJWTService getTokenJwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _getTokenJwtService = getTokenJwtService;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUsuarioModel model) 
        {
            var user = new UsuarioEntity
            {
                UserName = model.UserName,
                Email = model.Email, 
                Nombre = model.Nombre,
                Apellido = model.Apellido
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(ResponseApiService.Response(400, result.Errors));
            }

            await _userManager.AddToRoleAsync(user, "Cliente");

            return StatusCode(201, ResponseApiService.Response(201, new { UserId = user.Id }));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized(ResponseApiService.Response(401, null, "Usuario o contraseña inválidos."));
            }

            // Verificar la contraseña
            // CheckPasswordSignInAsync compara el hash
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(ResponseApiService.Response(401, null, "Usuario o contraseña inválidos."));
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _getTokenJwtService.Execute(user.Id.ToString(), roles.FirstOrDefault());

            return Ok(ResponseApiService.Response(200, new { token }));
        }
    }
}