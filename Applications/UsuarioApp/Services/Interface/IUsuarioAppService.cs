using UsersApi.Applications.UsuarioApp.DTO.Request;
using UsersApi.Applications.UsuarioApp.DTO.Response;
using UsersApi.Entities.Usuarios;

namespace UsersApi.Applications.UsuarioApp.Services.Interface
{
    public interface IUsuarioAppService
    {
        void CadastrarUsuario(UsuarioRequest request);
        IList<UsuarioResponse> BuscarUsuarios();
        Usuario AutenticarUsuario(string email, string senha);

    }
}
