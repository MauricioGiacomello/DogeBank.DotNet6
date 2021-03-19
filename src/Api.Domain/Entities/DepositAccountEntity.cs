namespace Api.Domain.Entities
{
    public class SolicitacaoSaqueDeposito
    {
        public int accountNumber { get; set; }
        public double valueDeposit { get; set; }
        public string tipoDeMovimentação { get; set; }
    }
}
