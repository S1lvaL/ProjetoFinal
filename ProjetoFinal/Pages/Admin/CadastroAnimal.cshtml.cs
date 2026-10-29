using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Pages.Admin
{
    public class CadastroAnimalModel : PageModel
    {
        private readonly AnimaisDB _animaisdb;
        private readonly CategoriaDB _categoriadb;

        public List<Categoria> Categorias { get; set; } = new();
        public string Mensagem { get; set; } = "";

        public CadastroAnimalModel(AnimaisDB animaisdb, CategoriaDB categoriadb)
        {
            _animaisdb = animaisdb;
            _categoriadb = categoriadb;
        }

        public void OnGet()
        {
            Categorias = _categoriadb.Listar();
        }

        public void OnPost()
        {

            string nome = Request.Form["nome"].ToString();
            string sintomas = Request.Form["sintomas"].ToString();
            string primeirosSocorros = Request.Form["primeirossocorros"].ToString();
            string naofazer = Request.Form["naofazer"].ToString();
            string regiaoOcorrencia = Request.Form["regiaoocorrencia"].ToString();
            string periculosidade = Request.Form["periculosidade"].ToString();
            int categoria = int.Parse(Request.Form["categoria"].ToString());
            Animal animal = new Animal(categoria, nome, sintomas, primeirosSocorros, naofazer, regiaoOcorrencia, periculosidade);
            int quant = _animaisdb.Incluir(animal);
            Mensagem = quant > 0
                ? "Animal  cadastrado com sucesso!"
                : "Nenhum registro inserido";
            Categorias = _categoriadb.Listar();
        }
    }
}
