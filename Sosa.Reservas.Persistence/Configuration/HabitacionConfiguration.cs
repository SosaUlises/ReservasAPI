using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Habitacion;
using Sosa.Reservas.Domain.Entidades.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.Configuration
{
    public class HabitacionConfiguration
    {
        public HabitacionConfiguration(EntityTypeBuilder<HabitacionEntity> entityBuilder)
        {
            entityBuilder.ToTable("Habitacion");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Numero).IsRequired();
            entityBuilder.Property(x => x.Activa).IsRequired();
            entityBuilder.Property(x => x.Tipo).IsRequired();
            entityBuilder.Property(x => x.CapacidadPersonas).IsRequired();
            entityBuilder.Property(x => x.PrecioPorNoche).IsRequired();
            entityBuilder.Property(x => x.HotelId).IsRequired();

            entityBuilder
                         .HasMany(h => h.Reservas)
                         .WithOne(h => h.Habitacion)
                         .HasForeignKey(h => h.HabitacionId)
                         .OnDelete(DeleteBehavior.Cascade);

            entityBuilder
                        .HasOne(h => h.Hotel)
                        .WithMany(h => h.Habitaciones)
                        .HasForeignKey(h => h.HotelId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
