using FluentValidation;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;

namespace Sosa.Reservas.Application.Validators.Cliente
{
    public class UpdateClienteValidator : AbstractValidator<UpdateClienteModel>
    {
        public UpdateClienteValidator()
        {
            RuleFor(x => x.Dni).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.Telefono).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Apellido).NotEmpty().NotNull();
            RuleFor(x => x.Nombre).NotEmpty().NotNull();
        }
    }
}
