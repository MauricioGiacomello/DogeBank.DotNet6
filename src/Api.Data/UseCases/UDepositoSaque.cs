using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementation;
using Api.Data.Repository;
using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UserCases
{
    public class UDepositoSaque : BaseRepository<AccountEntity>, IUDepositoSaque
    {
        private DbSet<AccountEntity> _dataset;
        private TransferenciaContasEntity _contas;

        public UDepositoSaque(MyContext context, TransferenciaContasEntity contas) : base(context)
        {
            _dataset = context.Set<AccountEntity>();
            _contas = contas;
        }

        public async Task<AccountEntity> Deposito(AccountEntity dadosConta, double valorDeposito)
        {
            try
            {
                dadosConta.balanceCredit = dadosConta.balanceCredit + valorDeposito;
                dadosConta.UpdateAt = DateTime.UtcNow;
                dadosConta.CreateAt = dadosConta.CreateAt;
                _context.Entry(dadosConta).CurrentValues.SetValues(dadosConta);
                await _context.SaveChangesAsync();
                return dadosConta;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error! Try again! " + ex.Message);
                return null;
            }
        }

        public async Task<AccountEntity> Saque(AccountEntity dadosConta, double valorSaque)
        {
            try
            {
                if (dadosConta.balanceCredit < valorSaque)
                    return null;

                dadosConta.balanceCredit = dadosConta.balanceCredit - valorSaque;
                dadosConta.UpdateAt = DateTime.UtcNow;
                dadosConta.CreateAt = dadosConta.CreateAt;
                _context.Entry(dadosConta).CurrentValues.SetValues(dadosConta);
                await _context.SaveChangesAsync();
                return dadosConta;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error! Try again! " + ex.Message);
                return null;
            }
        }
    }
}
