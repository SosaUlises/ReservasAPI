using FluentValidation;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;

namespace Sosa.Reservas.Application.Validators.Cliente
{
    public class CreateClienteValidator : AbstractValidator<CreateClienteModel>
    {
        public CreateClienteValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty();
            RuleFor(x => x.DNI).NotNull().NotEmpty();   
        }
    }
}
