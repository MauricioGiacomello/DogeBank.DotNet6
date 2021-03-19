using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases
{
    public class UCriarContaBanc : BaseRepository<AccountEntity>, IUCriarContaBanc
    {
        private DbSet<AccountEntity> _dataset;
        private BaseRepository<AccountEntity> _baseRepository;


        public UCriarContaBanc(MyContext context, BaseRepository<AccountEntity> baseRepository)
        : base(context)
        {
            _baseRepository = baseRepository;
            _dataset = context.Set<AccountEntity>();
        }

        public async Task<AccountEntity> FiltarDadosCriar(CriarContaBancariaRequest dadosConta)
        {
            try
            {
                var contaBase = new AccountEntity();
                IEnumerable<AccountEntity> todasContas = await _baseRepository.SelectAsync();

                var result = todasContas.Select(c => c.accountNumber).Max();

                if (result != null)
                {
                    contaBase.accountNumber = result + 1;
                    contaBase.userMF = dadosConta.cpf;
                    contaBase.accountType = dadosConta.accountType;
                    return await CriarContaBancoDados(contaBase);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AccountEntity> CriarContaBancoDados(AccountEntity dadosConta)
        {
            try
            {
                return await _baseRepository.InsertAsync(dadosConta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

