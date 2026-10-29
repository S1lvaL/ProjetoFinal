namespace ProjetoFinal.Models
{
    public class Animal
    {
        public int AnimalId { get; private set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sintomas { get; set; } = string.Empty;
        public string PrimeirosSocorros { get; set; } = string.Empty;
        public string NaoFazer { get; set; } = string.Empty;
        public string RegiaoOcorrencia { get; set; } = string.Empty;
        public string Periculosidade { get; set; } = string.Empty;

        public Animal (int animalId)
        {
            AnimalId = animalId;
        }
        public Animal(int categoriaId, string nome, string sintomas, string primeirosSocorros, string naofazer, string regiaoOcorrencia, string periculosidade)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Sintomas = sintomas;
            PrimeirosSocorros = primeirosSocorros;
            NaoFazer = naofazer;
            RegiaoOcorrencia = regiaoOcorrencia;
            Periculosidade = periculosidade;
        }
    }
}
