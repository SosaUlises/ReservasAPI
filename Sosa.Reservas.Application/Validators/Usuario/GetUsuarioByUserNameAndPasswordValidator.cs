using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Validators.Usuario
{
    public class GetUsuarioByUserNameAndPasswordValidator : AbstractValidator<(string,string)>
    {
        public GetUsuarioByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Item2).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
