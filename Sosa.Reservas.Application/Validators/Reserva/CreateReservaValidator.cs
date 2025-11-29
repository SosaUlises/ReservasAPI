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
            RuleFor(x => x.HabitacionId).NotEmpty().NotNull();
            RuleFor(x => x.CheckIn).NotEmpty().NotNull();
            RuleFor(x => x.CheckOut).NotEmpty().NotNull();
            RuleFor(x => x.CantidadPersonas).NotEmpty().NotNull();
        }
    }
}
