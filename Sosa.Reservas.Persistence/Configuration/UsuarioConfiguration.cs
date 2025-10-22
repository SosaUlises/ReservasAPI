using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosa.Reservas.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<UsuarioEntity> entityBuilder)
        {
            entityBuilder.ToTable("Usuario");
            entityBuilder.Property(x=> x.Nombre).IsRequired();
            entityBuilder.Property(x => x.Apellido).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired();

            entityBuilder.HasMany(x => x.Reservas)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
