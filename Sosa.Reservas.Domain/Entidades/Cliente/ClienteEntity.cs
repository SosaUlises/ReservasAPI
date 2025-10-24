using Sosa.Reservas.Common.SoftDelete;
using Sosa.Reservas.Domain.Entidades.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Domain.Entidades.Cliente
{
    public class ClienteEntity : ISoftDelete
    {
        public int ClienteId { get; set; }
        public string FullName { get; set;}
        public string DNI {  get; set; }

        public ICollection<ReservaEntity> Reservas { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
