using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.App.UsuarioApp.DTO.Request;
using Users.App.Usuarios.Services;

namespace Users.Api.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioAppService _usuarioServices;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioAppService usuarioServices)
        {
            _logger = logger;
            _usuarioServices = usuarioServices;
        }

        /// <summary>
        /// Cadastra usuário.
        /// </summary>
        /// <param name="request">Dados contendo informações do usuário.</param>
        /// <returns>Retorna sucesso caso o usuário seja cadastrado.</returns>
        /// <response code="200">Usuário cadastrado com sucesso.</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] UsuarioRequest request)
        {
            _usuarioServices.CadastrarUsuario(request);
            return Created();
        }

        /// <summary>
        /// Retorna lista de usuários.
        /// </summary>
        /// /// <remarks>
        /// O usuário deve estar autenticado com a policy "Admin".
        /// </remarks>
        /// <returns>Retorna sucesso caso a lista de usuários exista.</returns>
        /// <response code="200">Lista de usuários retornada com sucesso.</response>
        /// <response code="400">Requisição inválida</response>
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult BuscarUsuarios()
        {
            return Ok(_usuarioServices.BuscarUsuarios());
        }
    }
}
