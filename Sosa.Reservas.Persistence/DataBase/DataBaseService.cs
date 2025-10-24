using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase;
using Sosa.Reservas.Common.SoftDelete;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Persistence.Configuration;
using System.Linq.Expressions;

namespace Sosa.Reservas.Persistence.DataBase
{
    public class DataBaseService : IdentityDbContext<UsuarioEntity, IdentityRole<int>, int>, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<ReservaEntity> Reservas { get; set; }


        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<int>>(e => e.ToTable("Role"));
            modelBuilder.Entity<IdentityUserRole<int>>(e => e.ToTable("UsuarioRole"));
            modelBuilder.Entity<IdentityUserClaim<int>>(e => e.ToTable("UsuarioClaim"));
            modelBuilder.Entity<IdentityRoleClaim<int>>(e => e.ToTable("RoleClaim"));
            modelBuilder.Entity<IdentityUserLogin<int>>(e => e.ToTable("UsuarioLogin"));
            modelBuilder.Entity<IdentityUserToken<int>>(e => e.ToTable("UsuarioToken"));

            EntityConfiguration(modelBuilder);


            // Configuracion para Soft Delete para aplicarlo de forma global en el proyecto y ocultar datos eliminamos
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseService).Assembly);

            // Itera sobre todas las entidades del modelo
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Si la entidad implementa interfaz ISoftDelete
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    // Aplica el filtro global
                    modelBuilder.Entity(entityType.ClrType)
                           .HasQueryFilter(ConvertToDeleteFilter(entityType.ClrType));
                }
            }
        }

        // Metodo para crear el filtro dinamicamente
        private static LambdaExpression ConvertToDeleteFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");

            var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));

            var body = Expression.Equal(property, Expression.Constant(false));

            return Expression.Lambda(body, parameter);
        }

        

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguration(modelBuilder.Entity<UsuarioEntity>());
            new ReservaConfiguration(modelBuilder.Entity<ReservaEntity>());
            new ClienteConfiguration(modelBuilder.Entity<ClienteEntity>());
        }
    }
}
