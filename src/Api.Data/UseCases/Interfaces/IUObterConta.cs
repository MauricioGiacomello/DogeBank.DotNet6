using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.UserCases.Interfaces
{
    public interface IUObterConta
    {
        Task<AccountEntity> ConfigDepositoSaque(SolicitacaoSaqueDeposito account);
    }
}
