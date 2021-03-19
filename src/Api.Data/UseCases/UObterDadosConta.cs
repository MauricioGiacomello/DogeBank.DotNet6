using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases
{
    public class UObterDadosConta : BaseRepository<AccountEntity>, IUObterDadosConta
    {
        private DbSet<AccountEntity> _dataset;
        public UObterDadosConta(MyContext context) : base(context)
        {
            _dataset = context.Set<AccountEntity>();
        }
        public async Task<AccountEntity> ObterConta(int numeroConta)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.accountNumber == numeroConta);
        }
    }
}
