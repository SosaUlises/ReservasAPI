using FluentValidation;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.CreateUsuario;

namespace Sosa.Reservas.Application.Validators.Usuario
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioModel>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Apellido).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
