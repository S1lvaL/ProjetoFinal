using ProjetoFinal.Models;
using System.Data.SQLite;

namespace ProjetoFinal.Data
{
    public class AnimaisDB
    {
        private string conn;
        public AnimaisDB()
        {
        }
        public AnimaisDB(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("banco")
                ?? throw new InvalidOperationException("String de conexao 'banco' não encontrada");
        }
        public SQLiteConnection CriarConexao()
        {
            return new SQLiteConnection(conn);
        }

        public int Incluir(Animal Animal)
        {
            string sql = @"insert into Animal(NomePopular, Sintomas, PrimeirosSocorros, NaoFazer, RegiaoOcorrencia, Periculosidade, CategoriaId)
                            values(@pnome, @psintomas, @pprimeirossocorros, @pnaofazer, @pregiaoocorrencia, @ppericulosidade, @pcategoriaid)";

            using (SQLiteConnection conexao = new SQLiteConnection(conn))
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@pnome", Animal.Nome);
                comando.Parameters.AddWithValue("@psintomas", Animal.Sintomas);
                comando.Parameters.AddWithValue("@pprimeirossocorros", Animal.PrimeirosSocorros);
                comando.Parameters.AddWithValue("@pnaofazer", Animal.NaoFazer);
                comando.Parameters.AddWithValue("@pregiaoocorrencia", Animal.RegiaoOcorrencia);
                comando.Parameters.AddWithValue("@ppericulosidade", Animal.Periculosidade);
                comando.Parameters.AddWithValue("@pcategoriaid", Animal.CategoriaId);

                conexao.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public List<Animal> Listar()
        {
            var lista = new List<Animal>();
            string sql = @"select AnimalId, NomePopular, Sintomas, PrimeirosSocorros, NaoFazer,
                                  RegiaoOcorrencia, Periculosidade, CategoriaId
                           from Animal order by NomePopular";

            using (SQLiteConnection conexao = new SQLiteConnection(conn))
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();
                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Animal(leitor.GetInt32(0))
                        {
                            Nome = Texto(leitor, 1),
                            Sintomas = Texto(leitor, 2),
                            PrimeirosSocorros = Texto(leitor, 3),
                            NaoFazer = Texto(leitor, 4),
                            RegiaoOcorrencia = Texto(leitor, 5),
                            Periculosidade = Texto(leitor, 6),
                            CategoriaId = leitor.GetInt32(7)
                        });
                    }
                }
            }
            return lista;
        }

        private static string Texto(SQLiteDataReader leitor, int posicao)
        {
            return leitor.IsDBNull(posicao) ? "" : leitor.GetString(posicao);
        }
    }
}