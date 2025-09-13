using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<GetAllReservasModel>> Execute()
        {
            var listEntities = await _dataBaseService.Reservas.ToListAsync();

            return _mapper.Map<List<GetAllReservasModel>>(listEntities);
        }
    }
}
