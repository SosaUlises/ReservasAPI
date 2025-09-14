using FluentValidation;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.UpdateCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Cliente
{
    public class UpdateClienteValidator : AbstractValidator<UpdateClienteModel>
    {
        public UpdateClienteValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull();
            RuleFor(x => x.DNI).NotEmpty().NotNull();
            RuleFor(x => x.ClienteId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
