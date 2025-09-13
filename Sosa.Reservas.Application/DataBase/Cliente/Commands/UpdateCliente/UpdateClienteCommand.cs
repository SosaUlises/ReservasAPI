using AutoMapper;
using Sosa.Reservas.Domain.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IUpdateClienteCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateClienteCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateClienteModel> Execute(UpdateClienteModel model)
        {
            var entity = _mapper.Map<ClienteEntity>(model);

            _dataBaseService.Clientes.Update(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }

    }
}
