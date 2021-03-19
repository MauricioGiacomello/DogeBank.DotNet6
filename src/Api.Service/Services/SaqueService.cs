using System;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UserCases;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;

namespace Api.Service.Services
{
    public class SaqueService : ISaqueService
    {
        private UObterDadosConta _buscarConta;
        private UDepositoSaque _fazerSaque;

        public SaqueService(UObterDadosConta buscarConta, UDepositoSaque fazerSaque)
        {
            _buscarConta = buscarConta;
            _fazerSaque = fazerSaque;
        }
        public async Task<AccountEntity> Saque(SolicitacaoSaqueRequest dadosConta)
        {
            try
            {
                var result = await _buscarConta.ObterConta(dadosConta.numeroConta);

                if (result == null)
                    return null;

                return await _fazerSaque.Saque(result, dadosConta.valorSaque);

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
