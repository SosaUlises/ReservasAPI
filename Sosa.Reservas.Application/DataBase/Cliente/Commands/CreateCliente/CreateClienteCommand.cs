using AutoMapper;
using Sosa.Reservas.Domain.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente
{
    public class CreateClienteCommand : ICreateClienteCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateClienteCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateClienteModel> Execute(CreateClienteModel model)
        {
            var entity = _mapper.Map<ClienteEntity>(model);
            await _dataBaseService.Clientes.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
