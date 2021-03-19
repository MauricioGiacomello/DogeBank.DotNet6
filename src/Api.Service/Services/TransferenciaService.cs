using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UserCases;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private UObterDadosConta _buscarContas;
        private UDepositoSaque _fazerOperacoes;

        public TransferenciaService(UObterDadosConta buscarContas, UDepositoSaque fazerOperacoes)
        {
            _buscarContas = buscarContas;
            _fazerOperacoes = fazerOperacoes;
        }

        public async Task<AccountEntity> BuscarContas(TransferenciaContasEntity dadosContas)
        {
            var resultDebitado = await _buscarContas.ObterConta(dadosContas.numeroContaDebitado);
            var resultCreditado = await _buscarContas.ObterConta(dadosContas.numeroContaCreditado);

            return await FazerOperacoes(resultDebitado, resultCreditado, dadosContas.valorDebitado);

        }

        public async Task<AccountEntity> FazerOperacoes(AccountEntity debitado, AccountEntity creditado, double valorTransacao)
        {
            try
            {
                var result = await _fazerOperacoes.Saque(debitado, valorTransacao);

                if (result != null)
                {
                    result = await _fazerOperacoes.Deposito(creditado, valorTransacao);
                }

                return result;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }
    }
}
