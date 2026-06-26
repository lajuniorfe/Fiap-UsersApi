

using Users.Dominio.Usuarios;
using Users.Dominio.Usuarios.Enums;
using Users.Infra.Context;

namespace Users.Api.Dominio.Base
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Usuario.Any())
                return;

            context.Usuario.AddRange(
                new Usuario("Usuario teste 1", "teste1@teste.com", "@Teste123456", TipoUsuarioEnum.Usuario),
                new Usuario("Usuario teste 2", "teste2@teste.com", "@Teste123456", TipoUsuarioEnum.Administrador)
              );

            context.SaveChanges();
        }
    }
}
