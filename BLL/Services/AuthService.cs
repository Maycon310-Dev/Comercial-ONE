using BCrypt.Net;
using Comercial_ONE.DAL.Repositories;
using Comercial_ONE.Models;

namespace Comercial_ONE.BLL.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository _repository;
        public static Usuario UsuarioLogado { get; private set; }

        public AuthService()
        {
            _repository = new UsuarioRepository();
        }

        public bool Autenticar(string login, string senhaDigitada)
        {
            Usuario usuario = _repository.BuscarPorLogin(login);
            if (usuario == null || usuario.Ativo == false)
            {
                return false;
            }
            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senhaDigitada, usuario.SenhaHash);

            if (senhaCorreta)
            {
                UsuarioLogado = usuario; 
                return true;
            }

            return false;
        }
        public string GerarHash(string senhaNormal)
        {
            return BCrypt.Net.BCrypt.HashPassword(senhaNormal);
        }
    }
}