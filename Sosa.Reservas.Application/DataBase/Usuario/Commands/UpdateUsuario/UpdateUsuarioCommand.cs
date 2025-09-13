using AutoMapper;
using Sosa.Reservas.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IUpdateUsuarioCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUsuarioModel> Execute(UpdateUsuarioModel model)
        {
            var entity = _mapper.Map<UsuarioEntity>(model);
            _dataBaseService.Usuarios.Update(entity);
            await _dataBaseService.SaveAsync();

            return model;
        } 
    }
}
