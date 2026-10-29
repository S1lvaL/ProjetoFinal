namespace ProjetoFinal.Models
{
    public class DicaPrevencao
    {
        public int PrevencaoId { get; private set; }
        public int AnimalId { get; set; } 
        public string Ambiente { get; set; } = string.Empty;
        public string Checklist { get; set; } = string.Empty;

        public DicaPrevencao(int prevencaoId)
        {
            PrevencaoId = prevencaoId;
        }

        public DicaPrevencao(int animalid, string ambiente, string checklist)
        { 
            AnimalId = animalid;
            Ambiente = ambiente;
            Checklist = checklist;
        }
    }
}
