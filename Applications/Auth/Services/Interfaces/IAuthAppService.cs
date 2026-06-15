using UsersApi.Applications.Auth.DTO;

namespace UsersApi.Applications.Auth.Services.Interfaces
{
    public interface IAuthAppService
    {
        public string Logar(AuthUsuario authUsuario);
        public string Deslogar();
    }
}
