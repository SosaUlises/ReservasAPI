using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetReservasByTipo
{
    public interface IGetReservasByTipoQuery
    {
        Task<List<GetReservasByTipoModel>> Execute(string tipo);
    }
}
