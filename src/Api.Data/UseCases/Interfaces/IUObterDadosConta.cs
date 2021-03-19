using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUObterDadosConta
    {
        Task<AccountEntity> ObterConta(int numeroConta);
    }
}
