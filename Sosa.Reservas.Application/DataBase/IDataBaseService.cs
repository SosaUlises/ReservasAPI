using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;


namespace Sosa.Reservas.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<ClienteEntity> Clientes { get; set; }
        DbSet<ReservaEntity> Reservas { get; set; }
        Task<bool> SaveAsync();

    }
}
