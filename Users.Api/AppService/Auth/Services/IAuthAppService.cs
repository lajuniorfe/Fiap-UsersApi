using Users.Api.AppService.Auth.DTOs;

namespace Users.Api.AppService.Auth.Services
{
    public interface IAuthAppService
    {
        public string Logar(AuthUsuario authUsuario);
        public string Deslogar();
    }
}
