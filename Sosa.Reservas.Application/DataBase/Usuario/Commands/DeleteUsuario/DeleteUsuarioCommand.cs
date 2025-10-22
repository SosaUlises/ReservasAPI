using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IDeleteUsuarioCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteUsuarioCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _dataBaseService.Usuarios.FirstOrDefaultAsync(e => e.Id == userId);

            if (entity == null)
            {
                return false;
            }
            else
            {
                _dataBaseService.Usuarios.Remove(entity);
                return await _dataBaseService.SaveAsync();
            }
        }
    }
}
