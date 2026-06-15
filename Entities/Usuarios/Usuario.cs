using System.Text.RegularExpressions;
using UsersApi.Entities.Usuarios.Enums;

namespace UsersApi.Entities.Usuarios
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuarioEnum Tipo { get; set; }

        protected Usuario() { }

        public Usuario(string nome, string email, string senha, TipoUsuarioEnum tipoUsuario)
        {
            if (string.IsNullOrWhiteSpace(nome)) { throw new ArgumentNullException("Nome é obrigatório"); }

            if (!ValidarEmail(email))
                throw new ArgumentNullException("Email com formato inválido!");

            if (!ValidarSenha(senha))
                throw new ArgumentNullException("Senha fora dos padrões obrigatórios!");


            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Tipo = ValidarTipoUsuario(tipoUsuario);
            this.Id = Guid.NewGuid();
        }

        private bool ValidarSenha(string senha)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$");
            return regex.IsMatch(senha);
        }

        private bool ValidarEmail(string email)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        private TipoUsuarioEnum ValidarTipoUsuario(TipoUsuarioEnum tipoUsuario)
        {
            if (!Enum.IsDefined(typeof(TipoUsuarioEnum), tipoUsuario))
            {
                throw new ArgumentException("Tipo de usuário inválido");
            }

            return (TipoUsuarioEnum)tipoUsuario;
        }
    }
}
