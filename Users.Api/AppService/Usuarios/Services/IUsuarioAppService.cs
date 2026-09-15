using Users.Api.AppService.Usuarios.DTOs.Request;
using Users.Api.AppService.Usuarios.DTOs.Response;
using Users.Dominio.Usuarios;

namespace Users.Api.AppService.Usuarios.Services
{
    public interface IUsuarioAppService
    {
        Task CadastrarUsuario(UsuarioRequest request);
        IList<UsuarioResponse> BuscarUsuarios();
        Usuario AutenticarUsuario(string email, string senha);

    }
}
