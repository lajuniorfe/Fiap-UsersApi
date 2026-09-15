using Microsoft.EntityFrameworkCore;
using Users.Dominio.Usuarios;
using Users.Dominio.Usuarios.Repository;
using Users.Infra.Context;

namespace Users.Infra.Usuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<Usuario> _dbSet;

        public UsuarioRepository(ApplicationDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<Usuario>();
        }

        public void Alterar(Usuario entidade)
        {
            _context.Update(entidade);
            _context.SaveChanges();
        }

        public void Cadastrar(Usuario entidade)
        {
            _context.Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _context.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public IList<Usuario> ObterDados()
            => _dbSet.ToList();

        public Usuario ObterPorId(Guid id)
            => _dbSet.FirstOrDefault(entity => entity.Id == id);

        public Usuario? AutenticarUsuario(string email, string senha)
        {
            return _dbSet.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario? BuscarUsuarioEmail(string email)
        {
            return _dbSet.FirstOrDefault(u => u.Email == email);
        }
    }
}
