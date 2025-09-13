using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IGetClienteByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetClienteByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService; 
            _mapper = mapper;
        }

        public async Task<GetClienteByIdModel> Execute(int id)
        {
            var entity = await _dataBaseService.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);

            return _mapper.Map<GetClienteByIdModel>(entity);
        }
    }
}
