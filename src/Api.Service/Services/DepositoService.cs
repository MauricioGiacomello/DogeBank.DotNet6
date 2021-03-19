using System;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UserCases;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;

namespace Api.Service.Services
{
    public class DepositoService : IDepositoService
    {
        private UObterDadosConta _buscarConta;
        private UDepositoSaque _fazerDeposito;

        public DepositoService(UObterDadosConta buscarConta, UDepositoSaque fazerDeposito)
        {
            _buscarConta = buscarConta;
            _fazerDeposito = fazerDeposito;
        }

        public async Task<AccountEntity> Deposito(SolicitacaoDepositoRequest dadosConta)
        {
            try
            {
                var result = await _buscarConta.ObterConta(dadosConta.numeroConta);

                if (result == null)
                    return null;

                return await _fazerDeposito.Deposito(result, dadosConta.valorDeposito);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
