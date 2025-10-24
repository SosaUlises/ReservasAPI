using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;



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

        public async Task<IPagedList<GetAllClienteModel>> Execute(int pageNumber, int pageSize)
        {
            var query = _dataBaseService.Clientes.AsQueryable();

            var queryDto = query.ProjectTo<GetAllClienteModel>(_mapper.ConfigurationProvider);

            var pagedData = await queryDto.ToPagedListAsync(pageNumber, pageSize);

            return pagedData;   
        }
    }
}
