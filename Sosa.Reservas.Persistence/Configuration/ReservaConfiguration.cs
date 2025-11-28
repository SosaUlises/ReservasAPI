using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Cliente;
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
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.CodigoReserva).IsRequired();
            entityBuilder.Property(x=>x.CantidadPersonas).IsRequired();
            entityBuilder.Property(x => x.PrecioTotal).IsRequired();
            entityBuilder.Property(x => x.CheckIn).IsRequired();
            entityBuilder.Property(x => x.CheckOut).IsRequired();
            entityBuilder.Property(x => x.ClienteId).IsRequired();
            entityBuilder.Property(x => x.HabitacionId).IsRequired();

            entityBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.Reservas)
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            entityBuilder.HasOne(x => x.Habitacion)
                .WithMany(h => h.Reservas) 
                .HasForeignKey(x => x.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
