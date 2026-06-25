using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Dominio.Usuarios;

namespace Users.Infra.Usuarios.Configurations
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Senha).IsRequired();
            builder.Property(p => p.Tipo).HasConversion<string>();
        }
    }
}
