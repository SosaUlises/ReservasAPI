using FluentValidation;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuario;

namespace Sosa.Reservas.Application.Validators.Usuario
{
    public class UpdateUsuarioValidator : AbstractValidator<UpdateUsuarioModel>
    {
        public UpdateUsuarioValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Apellido).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
