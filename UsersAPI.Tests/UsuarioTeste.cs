namespace UsersAPI.Tests
{
    using Users.Dominio.Usuarios;
    using Users.Dominio.Usuarios.Enums;
    using Xunit;

    public class UsuarioServiceTests
    {
        [Fact]
        public void ValidarEmail_EmailValido_DeveRetornarTrue()
        {
            // Arrange
            var usuario = new Usuario("teste", "teste@email.com", "Senha123!", TipoUsuarioEnum.Usuario);


            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("teste@email.com", usuario.Email);
        }

        [Fact]
        public void ValidarEmail_EmailVazio_DeveRetornarFalse()
        {
            // Arrange
            var exception = Assert.Throws<ArgumentException>(() =>
                new Usuario(
                    "teste",
                    "",
                    "Senha123!",
                    TipoUsuarioEnum.Usuario
                )
            );

            // Assert
            Assert.NotNull(exception);
        }
    }
}
