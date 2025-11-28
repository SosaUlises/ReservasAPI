using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Entidades.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.Configuration
{
    public class HotelConfiguration
    {
        public HotelConfiguration(EntityTypeBuilder<HotelEntity> entityBuilder)
        {
            entityBuilder.ToTable("Hotel");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).IsRequired();
            entityBuilder.Property(x => x.Pais).IsRequired();
            entityBuilder.Property(x => x.Ciudad).IsRequired();
            entityBuilder.Property(x => x.Estrellas).IsRequired();

            entityBuilder
                         .HasMany(h => h.Habitaciones)
                         .WithOne(h => h.Hotel)
                         .HasForeignKey(h => h.HotelId)   
                         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
