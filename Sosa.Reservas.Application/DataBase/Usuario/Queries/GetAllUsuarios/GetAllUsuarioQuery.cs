using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios
{
    public class GetAllUsuarioQuery : IGetAllUsuarioQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllUsuarioQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllUsuarioModel>> Execute()
        {
            var listEntity = await _dataBaseService.Usuarios.ToListAsync();

            return _mapper.Map<List<GetAllUsuarioModel>>(listEntity);
        }
    }
}
