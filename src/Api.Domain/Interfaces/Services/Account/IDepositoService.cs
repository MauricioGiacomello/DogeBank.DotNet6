using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IDepositoService
    {
        Task<AccountEntity> Deposito(SolicitacaoDepositoRequest dadosConta);

    }
}
