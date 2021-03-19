using System.Threading.Tasks;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;

namespace Api.Service.Services
{
    public class AtualizarDadosService : IAtualizarDadosService
    {
        private UObterDadosAtualizacaoConta _obterContaUsuario;

        public AtualizarDadosService(UObterDadosAtualizacaoConta obterContaUsuario)
        {
            _obterContaUsuario = obterContaUsuario;
        }
        public async Task<AccountEntity> VerificarAtualizarConta(DadosAtualizacaoContaRequest dadosConta)
        {
            return await _obterContaUsuario.ObterContaAtualizacao(dadosConta);

        }
    }
}

