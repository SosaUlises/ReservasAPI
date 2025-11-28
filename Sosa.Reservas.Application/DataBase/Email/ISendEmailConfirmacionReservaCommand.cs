using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Habitacion;
using Sosa.Reservas.Domain.Entidades.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Email
{
    public interface ISendEmailConfirmacionReservaCommand
    {
        Task Execute(ReservaEntity reserva, ClienteEntity cliente, HabitacionEntity habitacion);
    }
}
