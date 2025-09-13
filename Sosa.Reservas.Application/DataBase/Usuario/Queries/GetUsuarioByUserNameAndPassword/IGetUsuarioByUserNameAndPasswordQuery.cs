using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioByUserNameAndPassword
{
    public interface IGetUsuarioByUserNameAndPasswordQuery
    {
        Task<GetUsuarioByUserNameAndPasswordModel> Execute(string userName, string password);
    }
}
