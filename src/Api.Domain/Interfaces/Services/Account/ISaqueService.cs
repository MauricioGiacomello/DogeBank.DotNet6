using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface ISaqueService
    {
        Task<AccountEntity> Saque(SolicitacaoSaqueRequest dadosConta);

    }
}
