namespace ProjetoFinal.Models
{
    public class Categoria
    {
        public int CategoriaId { get; private  set; }
        public string Grupo { get; set; } = string.Empty;

        public Categoria(int categoriaId)
        {
            CategoriaId = categoriaId;
        }
        public Categoria (string grupo)
        {
            Grupo = grupo;
        }
    }
}
