using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni
{
    public class GetClienteByDniQuery : IGetClienteByDniQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetClienteByDniQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetClienteByDniModel> Execute(string dni)
        {
            var entity = await _dataBaseService.Clientes.FirstOrDefaultAsync(x => x.DNI == dni);

            return _mapper.Map<GetClienteByDniModel>(entity);
        }
    }
}
