using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Queries.GetAllHoteles
{
    public class GetAllHotelesModel
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int Estrellas { get; set; }
    }
}
