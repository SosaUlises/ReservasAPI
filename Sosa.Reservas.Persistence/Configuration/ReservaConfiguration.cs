using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.Configuration
{
    public class ReservaConfiguration
    {
        public ReservaConfiguration(EntityTypeBuilder<ReservaEntity> entityBuilder)
        {
            entityBuilder.ToTable("Reserva");
            entityBuilder.HasKey(x => x.ReservaId);
            entityBuilder.Property(x => x.CodigoReserva).IsRequired();
            entityBuilder.Property(x=>x.TipoReserva).IsRequired();
            entityBuilder.Property(x => x.RegistrarFecha).IsRequired();
            entityBuilder.Property(x => x.UsuarioId).IsRequired();
            entityBuilder.Property(x => x.ClienteId).IsRequired();

            entityBuilder.HasOne(x => x.Usuario)
                .WithMany(x => x.Reservas)
                .HasForeignKey(x => x.UsuarioId);

            entityBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.Reservas)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
