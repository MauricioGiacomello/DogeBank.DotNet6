namespace Api.Domain.Dtos
{
    public class CriarContaBancariaRequest
    {
        public string email { get; set; }
        public string cpf { get; set; }
        public string accountType { get; set; }
    }
}
