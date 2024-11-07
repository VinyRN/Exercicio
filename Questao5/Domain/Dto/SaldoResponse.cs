namespace Questao5.Domain.Dto
{
    public class SaldoResponse
    {
        public int NumeroConta { get; set; }
        public string NomeTitular { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public decimal SaldoAtual { get; set; }
    }

}
