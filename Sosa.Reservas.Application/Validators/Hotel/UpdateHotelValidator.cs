using FluentValidation;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Hotel
{
    public class UpdateHotelValidator : AbstractValidator<UpdateHotelModel>
    {
        public UpdateHotelValidator()
        {
            RuleFor(x => x.Ciudad).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Pais).NotNull().NotEmpty();
            RuleFor(x => x.Estrellas).NotNull().NotEmpty();
            RuleFor(x => x.Nombre).NotNull().NotEmpty();
        }
    }
}
