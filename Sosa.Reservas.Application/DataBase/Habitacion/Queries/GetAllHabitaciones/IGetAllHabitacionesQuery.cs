using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sosa.Reservas.Application.DataBase.Habitacion.Queries.GetAllHabitaciones
{
    public interface IGetAllHabitacionesQuery
    {
        Task<IPagedList<GetAllHabitacionesModel>> Execute(int pageNumber, int pageSize);
    }
}
