using Microsoft.EntityFrameworkCore;
using UsersApi.Entities.Usuarios;

namespace UsersApi.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public void EnsureDatabaseCreated()
        {
            Database.Migrate();
        }
    }
}
