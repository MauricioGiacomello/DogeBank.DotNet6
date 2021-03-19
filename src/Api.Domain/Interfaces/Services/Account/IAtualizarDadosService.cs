using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IAtualizarDadosService
    {
        Task<AccountEntity> VerificarAtualizarConta(DadosAtualizacaoContaRequest dadosConta);

    }
}
