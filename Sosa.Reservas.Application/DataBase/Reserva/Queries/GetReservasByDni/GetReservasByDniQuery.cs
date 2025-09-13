using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByDni
{
    public class GetReservasByDniQuery : IGetReservasByDniQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetReservasByDniQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetReservasByDniModel>> Execute(string dni)
        {
            var listEntitis = await _dataBaseService.Reservas.Where(x => x.Cliente.DNI == dni).ToListAsync();
            return _mapper.Map<List<GetReservasByDniModel>>(listEntitis);
        }
    }
}
