using ProjetoFinal.Models;
using System.Data.SQLite;

namespace ProjetoFinal.Data
{
    public class DicaDB
    {
        private string conn;
        public DicaDB()
        {
        }
        public DicaDB(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("banco")
                ?? throw new InvalidOperationException("String de conexao 'banco' não encontrada");
        }
        public SQLiteConnection CriarConexao()
        {
            return new SQLiteConnection(conn);
        }

        public int Incluir(DicaPrevencao Dica)
        {
            string sql = @"insert into DicaPrevencao(AnimalId, Ambiente, Checklist)
                            values(@panimalid, @pambiente, @pchecklist)";

            using (SQLiteConnection conexao = new SQLiteConnection(conn))
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@panimalid", Dica.AnimalId);
                comando.Parameters.AddWithValue("@pambiente", Dica.Ambiente);
                comando.Parameters.AddWithValue("@pchecklist", Dica.Checklist);

                conexao.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public List<DicaPrevencao> Listar()
        {
            var lista = new List<DicaPrevencao>();
            string sql = "select PrevencaoId, AnimalId, Ambiente, Checklist from DicaPrevencao";

            using (SQLiteConnection conexao = new SQLiteConnection(conn))
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();
                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new DicaPrevencao(leitor.GetInt32(0))
                        {
                            AnimalId = leitor.GetInt32(1),
                            Ambiente = leitor.IsDBNull(2) ? "" : leitor.GetString(2),
                            Checklist = leitor.IsDBNull(3) ? "" : leitor.GetString(3)
                        });
                    }
                }
            }
            return lista;
        }
    }
}