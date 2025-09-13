using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByTipo
{
    public class GetReservasByTipoQuery : IGetReservasByTipoQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetReservasByTipoQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetReservasByTipoModel>> Execute(string tipo)
        {
            var listEntities = await _dataBaseService.Reservas.Include(x=>x.Cliente).Where(x => x.TipoReserva == tipo).ToListAsync();

            return _mapper.Map<List<GetReservasByTipoModel>>(listEntities);
        }
    }
}
