using Microsoft.AspNetCore.Mvc;
using Users.AppService.Auth.DTOs;
using Users.AppService.Auth.Services.Interfaces;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authService;
        public AuthController(IAuthAppService authService)
        {

            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthUsuario authUsuario)
        {
            var token = _authService.Logar(authUsuario);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);

        }

    }
}
