using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.EF;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetAllHabitaciones
{
    public class GetAllHabitacionesQuery : IGetAllHabitacionesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllHabitacionesQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<IPagedList<GetAllHabitacionesModel>> Execute(int pageNumber, int pageSize)
        {
            var query = _dataBaseService.Habitaciones.AsQueryable();

            var queryDto = query.ProjectTo<GetAllHabitacionesModel>(_mapper.ConfigurationProvider);

            var pagedData = await queryDto.ToPagedListAsync(pageNumber, pageSize);

            return pagedData;
        }
    }
}
