using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.Api.AppService.Auth.DTOs;
using Users.Api.AppService.Usuarios.Services;
using Users.Dominio.Usuarios;
using Users.Dominio.Usuarios.Enums;

namespace Users.Api.AppService.Auth.Services
{
    public class AuthAppService: IAuthAppService
    {
        private readonly IUsuarioAppService usuarioAppServices;
        private readonly IConfiguration _configuration;

        public AuthAppService(IUsuarioAppService usuarioAppServices, IConfiguration configuration)
        {
            this.usuarioAppServices = usuarioAppServices;
            _configuration = configuration;
        }

        public string Deslogar()
        {
            throw new NotImplementedException();
        }

        public string Logar(AuthUsuario authUsuario)
        {
            Usuario retornoUSuario = usuarioAppServices.AutenticarUsuario(authUsuario.Email, authUsuario.Senha);


            return retornoUSuario.Tipo == TipoUsuarioEnum.Usuario
                ? GerarToken(retornoUSuario, "User")
                : GerarToken(retornoUSuario, "Admin");
        }

        private string GerarToken(Usuario usuario, string role)
        {
            var claims = new[]
            {
                new  Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


