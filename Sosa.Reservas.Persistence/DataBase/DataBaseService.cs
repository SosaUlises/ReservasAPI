using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Interfaces;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
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
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguration(modelBuilder.Entity<UsuarioEntity>());
            new ReservaConfiguration(modelBuilder.Entity<ReservaEntity>());
            new ClienteConfiguration(modelBuilder.Entity<ClienteEntity>());
        }
    }
}
