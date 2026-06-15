using UsersApi.Applications.UsuarioApp.DTO.Request;
using UsersApi.Applications.UsuarioApp.DTO.Response;
using UsersApi.Applications.UsuarioApp.Services.Interface;
using UsersApi.Entities.Usuarios;
using UsersApi.Entities.Usuarios.Enums;
using UsersApi.Entities.Usuarios.Repository;
using UsersApi.Infra.Logger;

namespace UsersApi.Applications.UsuarioApp.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly BaseLogger<UsuarioAppService> _logger;


        public UsuarioAppService(IUsuarioRepository usuarioRepository, BaseLogger<UsuarioAppService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public void CadastrarUsuario(UsuarioRequest request)
        {
            try
            {
                Usuario usuario = new(request.Nome, request.Email, request.Senha, (TipoUsuarioEnum)request.TipoUsuario);

                Usuario? usuarioExistente = _usuarioRepository.BuscarUsuarioEmail(request.Email);

                if (usuarioExistente != null)
                    throw new Exception("Usuário existente!");

                _usuarioRepository.Cadastrar(usuario);
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
