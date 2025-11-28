using FluentValidation;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.CreateHabitacion;
using Sosa.Reservas.Application.DataBase.Habitacion.Command.UpdateHabitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Habitacion
{
    public class UpdateHabitacionValidator : AbstractValidator<UpdateHabitacionModel>
    {
        public UpdateHabitacionValidator()
        {
            RuleFor(x => x.Numero).NotNull().NotEmpty();
            RuleFor(x => x.Tipo).NotNull().NotEmpty();
            RuleFor(x => x.HotelId).NotNull().NotEmpty();
            RuleFor(x => x.PrecioPorNoche).NotNull().NotEmpty();
            RuleFor(x => x.CapacidadPersonas).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
