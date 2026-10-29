using ProjetoFinal.Models;
using System.Data.SQLite;

namespace ProjetoFinal.Data
{
    public class CategoriaDB
    {
        private readonly string conn;

        public CategoriaDB(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("banco")
                ?? throw new InvalidOperationException("String de conexao 'banco' não encontrada");
        }

        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();
            string sql = "select categoriaid, grupo from categoria order by grupo";

            using (var conexao = new SQLiteConnection(conn))
            using (var comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Categoria(leitor.GetInt32(0)) { Grupo = leitor.GetString(1) });
                    }
                }
            }
            return lista;
        }
    }
}