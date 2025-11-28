using FluentValidation;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Hotel
{
    public class CreateHotelValidator : AbstractValidator<CreateHotelModel>
    {
        public CreateHotelValidator()
        {
            RuleFor(x => x.Ciudad).NotNull().NotEmpty();
            RuleFor(x => x.Pais).NotNull().NotEmpty();
            RuleFor(x => x.Estrellas).NotNull().NotEmpty();
            RuleFor(x => x.Nombre).NotNull().NotEmpty();
        }
    }
}
