using Users.Api.AppService.Usuarios.DTOs.Request;
using Users.Api.AppService.Usuarios.DTOs.Response;
using Users.AppService.events;
using Users.Dominio.Usuarios;
using Users.Dominio.Usuarios.Enums;
using Users.Dominio.Usuarios.Repository;
using Users.Infra.Logger;

namespace Users.Api.AppService.Usuarios.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly BaseLogger<UsuarioAppService> _logger;
        private readonly IRabbitMqPublisher _publisher;


        public UsuarioAppService(IUsuarioRepository usuarioRepository, BaseLogger<UsuarioAppService> logger, IRabbitMqPublisher publishEndpoint)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
            _publisher = publishEndpoint;
        }

        public async Task CadastrarUsuario(UsuarioRequest request)
        {
            try
            {
                Usuario usuario = new(request.Nome, request.Email, request.Senha, (TipoUsuarioEnum)request.TipoUsuario);

                Usuario? usuarioExistente = _usuarioRepository.BuscarUsuarioEmail(request.Email);

                if (usuarioExistente != null)
                    throw new Exception("Usuário existente!");

                _usuarioRepository.Cadastrar(usuario);

                await _publisher.PublishAsync(
                     "user-created",
                     new UserCreatedEvent(usuario.Id, usuario.Nome, usuario.Email));

                _logger.LogInformation($"Usuário {request.Email} cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao cadastrar usuário: {ex.Message}");
                throw new Exception("Erro ao cadastrar usuário!");
            }
        }

        public IList<UsuarioResponse> BuscarUsuarios()
        {
            try
            {
                IList<Usuario> usuariosRetornados = _usuarioRepository.ObterDados();
                IList<UsuarioResponse> listaResponse = new List<UsuarioResponse>();

                if (usuariosRetornados == null)
                    throw new Exception("Usuários inexistentes!");

                foreach (var i in usuariosRetornados)
                {
                    UsuarioResponse response = new()
                    {
                        Id = i.Id,
                        Nome = i.Nome,
                        Email = i.Email
                    };

                    listaResponse.Add(response);
                }

                return listaResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar usuários: {ex.Message}");
                throw new Exception("Erro ao buscar usuários!"); ;
            }
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            try
            {
                Usuario? usuarioRetornado = _usuarioRepository.AutenticarUsuario(email, senha);

                if (usuarioRetornado != null)
                {
                    return usuarioRetornado;
                }

                _logger.LogInformation($"Falha no login! Email: {email}.");
                throw new Exception("Falha no login! Email ou senha incorretos.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao autenticar usuário: {ex.Message}");

                throw new Exception("Erro ao autenticar usuário!"); ;
            }

        }


    }
}
