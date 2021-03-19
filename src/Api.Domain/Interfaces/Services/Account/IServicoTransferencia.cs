using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface ITransferenciaService
    {
        Task<AccountEntity> BuscarContas(TransferenciaContasEntity dadosContas);
        Task<AccountEntity> FazerOperacoes(AccountEntity debitado, AccountEntity creditado, double valorTransacao);


    }
}
