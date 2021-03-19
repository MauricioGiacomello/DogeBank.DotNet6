using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.UserCases.Interfaces
{
    public interface IUDepositoSaque
    {
        Task<AccountEntity> Deposito(AccountEntity conta, double valorDeposito);
        Task<AccountEntity> Saque(AccountEntity conta, double valorSaque);
    }
}
