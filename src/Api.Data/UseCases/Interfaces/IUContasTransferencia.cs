using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IUObterContasTransferencia
    {
        Task<AccountEntity> ContasTransferencia(TransferenciaContasEntity contas);
    }
}

