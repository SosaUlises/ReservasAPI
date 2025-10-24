using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios
{
    public interface IGetAllUsuarioQuery
    {
        Task<IPagedList<GetAllUsuarioModel>> Execute(int pageNumber, int pageSize);
    }
}
