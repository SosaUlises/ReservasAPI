using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetAllClientes
{
    public class GetAllClienteQuery : IGetAllClienteQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllClienteQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllClienteModel>> Execute()
        {
            var listEntities = await _dataBaseService.Clientes.ToListAsync();

            return _mapper.Map<List<GetAllClienteModel>>(listEntities);   
        }
    }
}
