namespace Api.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public string accountType { get; set; }
        public double balanceCredit { get; set; }
        public int accountNumber { get; set; }
        public string userMF { get; set; }

    }
}
