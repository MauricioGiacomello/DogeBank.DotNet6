using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUObterDadosAtualizacaoConta
    {
        Task<AccountEntity> ObterContaAtualizacao(DadosAtualizacaoContaRequest dadosConta);
    }
}
