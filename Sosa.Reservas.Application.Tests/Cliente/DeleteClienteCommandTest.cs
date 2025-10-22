using Moq;
using Moq.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.DeleteCliente;
using Sosa.Reservas.Domain.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Tests.Cliente
{
    public class DeleteClienteCommandTest
    {
        private readonly Mock<IDataBaseService> _mockDbService;
        private readonly List<ClienteEntity> _listaDeClientes;
        private readonly DeleteClienteCommand _command;

        public DeleteClienteCommandTest()
        {
            _mockDbService = new Mock<IDataBaseService>();

            _listaDeClientes = new List<ClienteEntity>()
            {
                new ClienteEntity() { ClienteId = 1, FullName = "Sosa Ulises", DNI = "43767679"},
                new ClienteEntity() { ClienteId = 2, FullName = "Aguirre Clara", DNI = "43797676"},
            };


            _mockDbService.Setup(db => db.Clientes).ReturnsDbSet(_listaDeClientes);

            _command = new DeleteClienteCommand(_mockDbService.Object);
        }

        [Fact]
        public async Task Execute_DebeDevolverTrue_CuandoClienteExiste()
        {
            var clienteId = 1;

            _mockDbService.Setup(db => db.SaveAsync()).ReturnsAsync(true);

            var result = await _command.Execute(clienteId);

            Assert.True(result);

            // Verificamos que SaveAsync fue llamado
            _mockDbService.Verify(db => db.SaveAsync(), Times.Once());

        }

        [Fact]
        public async Task Execute_DebeDevolverFalse_CuandoClienteNoExiste()
        {
            var clienteId = 99; // Id falso

            var result = await _command.Execute(clienteId);


            Assert.False(result); // Afirmamos que el borrado falló (porque no se encontró)

            // Verificamos que SaveAsync nunca fue llamado
            _mockDbService.Verify(db => db.SaveAsync(), Times.Never());
        }
    }
}
