using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.Configuration
{
    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<ClienteEntity> entityBuilder)
        {
            entityBuilder.ToTable("Cliente");
            entityBuilder.HasKey(c => c.ClienteId);
            entityBuilder.Property(c => c.FullName).IsRequired();
            entityBuilder.Property(c => c.DNI).IsRequired();

            entityBuilder.HasMany(x => x.Reservas)
              .WithOne(x => x.Cliente)
              .HasForeignKey(x => x.ClienteId);
        }
    }
}
