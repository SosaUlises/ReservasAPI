using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;
using Sosa.Reservas.Domain.Entidades.Usuario;

public class UpdateUsuarioCommand : IUpdateUsuarioCommand
{

    private readonly UserManager<UsuarioEntity> _userManager;
    private readonly IMapper _mapper;

    public UpdateUsuarioCommand(UserManager<UsuarioEntity> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UpdateUsuarioModel> Execute(UpdateUsuarioModel model)
    {

        var entityFromDb = await _userManager.FindByIdAsync(model.UserId.ToString());

        if (entityFromDb == null)
        {

            throw new Exception("Usuario no encontrado");
        }

        _mapper.Map(model, entityFromDb);

        var result = await _userManager.UpdateAsync(entityFromDb);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }

        return model;
    }
}