using FluentValidation;
using Sosa.Reservas.Application.DataBase.Login.Command.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Login
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.");
        }
    }
}
