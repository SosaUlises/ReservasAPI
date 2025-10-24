using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;



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

       public async Task<IPagedList<GetAllUsuarioModel>> Execute(int pageNumber, int pageSize)
        {
            var query =  _dataBaseService.Usuarios.AsQueryable();

            var queryDto = query.ProjectTo<GetAllUsuarioModel>(_mapper.ConfigurationProvider);

            var pagedData = await queryDto.ToPagedListAsync(pageNumber, pageSize);

            return pagedData;
        }
    }
}
