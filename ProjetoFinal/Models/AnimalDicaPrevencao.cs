namespace ProjetoFinal.Models
{
    public class AnimalDicaPrevencao
    {
        public int AnimalId { get; set; }
        public int PrevencaoId { get; set; }

        public AnimalDicaPrevencao(int animalId, int prevencaoId)
        {
            AnimalId = animalId;
            PrevencaoId = prevencaoId;
        }
    }
}
