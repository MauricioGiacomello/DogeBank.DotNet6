using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUCriarContaBanc
    {
        Task<AccountEntity> FiltarDadosCriar(CriarContaBancariaRequest dadosUsuario);

        Task<AccountEntity> CriarContaBancoDados(AccountEntity dadosUsuario);

    }
}
