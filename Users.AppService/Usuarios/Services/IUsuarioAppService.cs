

using Users.App.UsuarioApp.DTO.Request;
using Users.App.UsuarioApp.DTO.Response;
using Users.Dominio.Usuarios;

namespace Users.App.Usuarios.Services
{
    public interface IUsuarioAppService
    {
        Task CadastrarUsuario(UsuarioRequest request);
        IList<UsuarioResponse> BuscarUsuarios();
        Usuario AutenticarUsuario(string email, string senha);

    }
}
