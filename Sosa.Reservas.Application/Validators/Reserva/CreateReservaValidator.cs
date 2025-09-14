using FluentValidation;
using Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Reserva
{
    public class CreateReservaValidator : AbstractValidator<CreateReservaModel>
    {
        public CreateReservaValidator()
        {
            RuleFor(x => x.ClienteId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.UsuarioId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.CodigoReserva).NotEmpty().NotNull();
            RuleFor(x => x.TipoReserva).NotEmpty().NotNull();
        }
    }
}
