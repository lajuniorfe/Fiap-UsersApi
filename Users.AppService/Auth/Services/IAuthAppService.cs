
using Users.AppService.Auth.DTOs;

namespace Users.AppService.Auth.Services.Interfaces
{
    public interface IAuthAppService
    {
        public string Logar(AuthUsuario authUsuario);
        public string Deslogar();
    }
}
