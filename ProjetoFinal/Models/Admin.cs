namespace ProjetoFinal.Models
{
    public class Admin
    {
        public int AdminId { get; private set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public Admin(int adminId)
        {
            AdminId = adminId;
        }
        public Admin(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
