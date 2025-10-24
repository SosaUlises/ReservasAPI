using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservas
{
    public class GetAllReservasQuery : IGetAllReservasQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllReservasQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<IPagedList<GetAllReservasModel>> Execute(int pageNumber, int pageSize)
        {
            var query =  _dataBaseService.Reservas.Include(x => x.Cliente).AsQueryable();

            var queryDto =  query.ProjectTo<GetAllReservasModel>(_mapper.ConfigurationProvider);

            var pagedData = await queryDto.ToPagedListAsync(pageNumber, pageSize);

            return pagedData;
        }
    }
}
