using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword
{
    public class UpdateUsuarioPasswordCommand : IUpdateUsuarioPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public UpdateUsuarioPasswordCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(UpdateUsuarioPasswordModel model)
        {
            var entity = await _dataBaseService.Usuarios.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (entity == null)
            {
                return false;
            }
            else
            {

               entity.Password = model.Password;

               return await _dataBaseService.SaveAsync();
            }
        }
    }
}
