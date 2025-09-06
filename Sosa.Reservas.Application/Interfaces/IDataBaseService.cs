using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Interfaces
{
    public interface IDataBaseService
    {
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<ClienteEntity> Clientes { get; set; }
        DbSet<ReservaEntity> Reservas { get; set; }
        Task<bool> SaveAsync();

    }
}
