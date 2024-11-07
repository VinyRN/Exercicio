namespace Questao5.Domain.Entities
{
    public class Atendimento
    {
        public Guid ID { get; set; }
        public string Assunto { get; set; } = string.Empty;
        public int Ano { get; set; }
    }
}
