using FluentValidation;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.UpdateUsuarioPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Usuario
{
    public class UpdateUsuarioPasswordValidator : AbstractValidator<UpdateUsuarioPasswordModel>
    {
        public UpdateUsuarioPasswordValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
