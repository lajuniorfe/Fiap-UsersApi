namespace Users.Api.AppService.Usuarios.DTOs.Request
{
    public class UsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public TipoUsuarioEnumRequest TipoUsuario { get; set; }
    }
}
