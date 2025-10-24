using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IDeleteClienteCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteClienteCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int id)
        {
            var entity = await _dataBaseService.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);

            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.IsDeleted = true;
                _dataBaseService.Clientes.Update(entity);
                return await _dataBaseService.SaveAsync();
            }
        }
    }
}
