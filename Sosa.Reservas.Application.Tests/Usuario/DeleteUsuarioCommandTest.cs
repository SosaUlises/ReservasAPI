using Microsoft.AspNetCore.Identity;
using Moq;
using Sosa.Reservas.Application.DataBase.Usuario.Commands.DeleteUsuario;
using Sosa.Reservas.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.Tests.Usuario
{
    public class DeleteUsuarioCommandTest
    {
        private readonly Mock<UserManager<UsuarioEntity>> _mockUserManager;

        public DeleteUsuarioCommandTest()
        {
            var userStoreMock = new Mock<IUserStore<UsuarioEntity>>();
            _mockUserManager = new Mock<UserManager<UsuarioEntity>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        [Fact]
        public async Task Execute_DebeDevolverTrue_CuandoUsuarioExisteYBorra()
        {
            // Arrange
            var userId = 1;
            var fakeUser = new UsuarioEntity { Id  = userId, UserName = "test" };

            // Set mock
            _mockUserManager.Setup(m => m.FindByIdAsync(userId.ToString()))
                            .ReturnsAsync(fakeUser);

            _mockUserManager.Setup(m => m.DeleteAsync(fakeUser))
                            .ReturnsAsync(IdentityResult.Success);

            var command = new DeleteUsuarioCommand(_mockUserManager.Object);

            // Act
            var result = await command.Execute(userId);

            // Assert 
            Assert.True(result);
        }

        [Fact]
        public async Task Execute_DebeDevolverFalse_CuandoUsuarioNoExiste()
        {
            var userId = 99;

            // Set mock
            _mockUserManager.Setup(m => m.FindByIdAsync(userId.ToString()))
                            .ReturnsAsync((UsuarioEntity)null); // Devuelve null

            var command = new DeleteUsuarioCommand(_mockUserManager.Object);

            // Act
            var result = await command.Execute(userId);

            // Assert
            Assert.False(result);

            // Verificamos que DeleteAsync NUNCA se llamó
            _mockUserManager.Verify(m => m.DeleteAsync(It.IsAny<UsuarioEntity>()), Times.Never());
        }
    }
}
