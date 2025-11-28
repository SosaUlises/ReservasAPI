using Sosa.Reservas.Common.SoftDelete;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;

namespace Sosa.Reservas.Domain.Entidades.Cliente
{
    public class ClienteEntity : ISoftDelete
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }
        public string? Telefono {  get; set; }
        public ICollection<ReservaEntity> Reservas { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
