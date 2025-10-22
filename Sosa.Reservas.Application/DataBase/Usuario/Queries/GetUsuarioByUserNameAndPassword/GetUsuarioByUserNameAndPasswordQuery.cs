using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword
{
    public class GetUsuarioByUserNameAndPasswordQuery : IGetUsuarioByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUsuarioByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUsuarioByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _dataBaseService.Usuarios.FirstOrDefaultAsync(x => x.UserName == userName && x.PasswordHash == password);

            return _mapper.Map<GetUsuarioByUserNameAndPasswordModel>(entity);
        }
    }
}
