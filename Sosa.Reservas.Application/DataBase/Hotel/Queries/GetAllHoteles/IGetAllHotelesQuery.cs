using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles
{
    public interface IGetAllHotelesQuery
    {
        Task<IPagedList<GetAllHotelesModel>> Execute(int pageNumber, int pageSize);
    }
}
