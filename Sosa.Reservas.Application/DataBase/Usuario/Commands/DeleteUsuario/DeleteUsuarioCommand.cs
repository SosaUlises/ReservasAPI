using Microsoft.AspNetCore.Identity;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IDeleteUsuarioCommand
    {

        private readonly UserManager<UsuarioEntity> _userManager;

        public DeleteUsuarioCommand(UserManager<UsuarioEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Execute(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
        }
    }
}
