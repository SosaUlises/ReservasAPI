using AutoMapper;
using Sosa.Reservas.Domain.Entidades.Usuario;


namespace Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : ICreateUsuarioCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUsuarioCommand(IMapper mapper, IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateUsuarioModel> Execute(CreateUsuarioModel model) 
        {
            var entity = _mapper.Map<UsuarioEntity>(model);

            // Hasheo y asignacion de contraseña manualmente
            entity.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _dataBaseService.Usuarios.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
