using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Pages.Admin
{
    public class CadastroDicasModel : PageModel
    {
        private readonly DicaDB _dicadb;
        private readonly AnimaisDB _animaisdb;

        public List<Animal> Animais { get; set; } = new();
        public string Mensagem { get; set; } = "";

        public CadastroDicasModel(DicaDB dicadb, AnimaisDB animaisdb)
        {
            _dicadb = dicadb;
            _animaisdb = animaisdb;
        }

        public void OnGet()
        {
            Animais = _animaisdb.Listar();
        }

        public void OnPost()
        {
            string ambiente = Request.Form["ambiente"].ToString();
            string checklist = Request.Form["checklist"].ToString();
            int animalId = int.Parse(Request.Form["animal"].ToString());

            DicaPrevencao dica = new DicaPrevencao(animalId, ambiente, checklist);
            int quant = _dicadb.Incluir(dica);
            Mensagem = quant > 0
                ? "Dica cadastrada com sucesso!"
                : "Nenhum registro inserido";

            Animais = _animaisdb.Listar();
        }
    }
}