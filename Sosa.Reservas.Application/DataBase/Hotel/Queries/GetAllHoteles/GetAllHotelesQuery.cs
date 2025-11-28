using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.EF;

namespace Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles
{
    public class GetAllHotelesQuery : IGetAllHotelesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllHotelesQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<IPagedList<GetAllHotelesModel>> Execute(int pageNumber, int pageSize)
        {
            var query = _dataBaseService.Hoteles.AsQueryable();

            var queryDto = query.ProjectTo<GetAllHotelesModel>(_mapper.ConfigurationProvider);

            var pagedData = await queryDto.ToPagedListAsync(pageNumber, pageSize);

            return pagedData;
        }
    }
}
