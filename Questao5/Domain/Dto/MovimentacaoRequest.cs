namespace Questao5.Domain.Dto
{
    public class MovimentacaoRequest
    {
        public string IdRequisicao { get; set; }
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public char TipoMovimento { get; set; } // 'C' para crédito, 'D' para débito
    }

}
