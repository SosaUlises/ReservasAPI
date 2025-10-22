using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IGetUsuarioByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<GetUsuarioByIdModel> Execute(int id)
        {
            var entity = await _dataBaseService.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<GetUsuarioByIdModel>(entity);
           
        }

    }
}
