using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases.Interfaces
{
    public class UObterDadosAtualizacaoConta : BaseRepository<AccountEntity>, IUObterDadosAtualizacaoConta
    {
        private DbSet<AccountEntity> _dataset;
        private BaseRepository<AccountEntity> _baseRepository;


        public UObterDadosAtualizacaoConta(MyContext context,
        BaseRepository<AccountEntity> baseRepository) : base(context)

        {
            _dataset = context.Set<AccountEntity>();
            _baseRepository = baseRepository;
        }

        public async Task<AccountEntity> ObterContaAtualizacao(DadosAtualizacaoContaRequest dadosConta)
        {
            var result = await _dataset.FirstOrDefaultAsync(u => u.accountNumber.Equals(dadosConta.accountNumber));

            result.accountType = dadosConta.accountType;
            result.userMF = dadosConta.userMF;

            return await FazerAtualização(result);
        }

        public async Task<AccountEntity> FazerAtualização(AccountEntity dadosConta)
        {

            return await _baseRepository.UpdateAsync(dadosConta);
        }

    }
}
