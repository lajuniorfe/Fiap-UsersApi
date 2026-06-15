using Microsoft.EntityFrameworkCore;
using UsersApi.Entities.Usuarios;
using UsersApi.Entities.Usuarios.Repository;
using UsersApi.Infra.Context;

namespace UsersApi.Infra.Usuarios.Repositories
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

        Usuario? IUsuarioRepository.AutenticarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        Usuario? IUsuarioRepository.BuscarUsuarioEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
