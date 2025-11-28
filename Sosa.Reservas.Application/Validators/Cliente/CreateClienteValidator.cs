using FluentValidation;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;

namespace Sosa.Reservas.Application.Validators.Cliente
{
    public class CreateClienteValidator : AbstractValidator<CreateClienteModel>
    {
        public CreateClienteValidator()
        {
            RuleFor(x => x.Dni).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();   
            RuleFor(x => x.Telefono).NotNull().NotEmpty();   
            RuleFor(x => x.Apellido).NotNull().NotEmpty();   
            RuleFor(x => x.Nombre).NotNull().NotEmpty();   
            RuleFor(x => x.Password).NotNull().NotEmpty();    
        }
    }
}
