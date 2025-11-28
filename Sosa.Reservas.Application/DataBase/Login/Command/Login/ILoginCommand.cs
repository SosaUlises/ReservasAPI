using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Login.Command.Login
{
    public interface ILoginCommand
    {
        Task<BaseResponseModel> Execute(LoginModel model);
    }
}
