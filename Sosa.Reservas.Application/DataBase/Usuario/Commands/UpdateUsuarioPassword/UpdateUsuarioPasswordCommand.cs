using Microsoft.AspNetCore.Identity;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword
{
    public class UpdateUsuarioPasswordCommand : IUpdateUsuarioPasswordCommand
    {
        private readonly UserManager<UsuarioEntity> _userManager;

        public UpdateUsuarioPasswordCommand(UserManager<UsuarioEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Execute(UpdateUsuarioPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());

            if (user == null)
            {
                return false;
            }

            var removeResult = await _userManager.RemovePasswordAsync(user);

            if (!removeResult.Succeeded)
            {
                return false;
            }

            var addResult = await _userManager.AddPasswordAsync(user, model.Password);

            return addResult.Succeeded;
        }
    }
}