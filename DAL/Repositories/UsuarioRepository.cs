using Dapper;
using Comercial_ONE.Models;
using MySql.Data.MySqlClient;

namespace Comercial_ONE.DAL.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _conexao = "SERVER=LOCALHOST;DATABASE=comercial_one;USER=root;PWD=1673jane;";

        public Usuario BuscarPorLogin(string login)
        {
            using (var conn = new MySqlConnection(_conexao))
            {
                string query = "SELECT id as Id, nome as Nome, login as Login, senha_hash as SenhaHash, perfil as Perfil, ativo as Ativo FROM usuarios WHERE login = @Login";

                return conn.QueryFirstOrDefault<Usuario>(query, new { Login = login });
            }
        }

    }
}
