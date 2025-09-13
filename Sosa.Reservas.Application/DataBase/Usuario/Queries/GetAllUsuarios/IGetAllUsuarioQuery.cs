using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios
{
    public interface IGetAllUsuarioQuery
    {
        Task<List<GetAllUsuarioModel>> Execute();
    }
}
