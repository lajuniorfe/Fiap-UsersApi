namespace Users.Dominio.Usuarios.Repository
{
    public interface IUsuarioRepository 
    {
        Usuario? BuscarUsuarioEmail(string email);
        Usuario? AutenticarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);

        IList<Usuario> ObterDados();
    }
}
