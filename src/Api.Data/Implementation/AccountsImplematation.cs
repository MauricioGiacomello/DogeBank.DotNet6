using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementation
{
    public class AccountsImplementation : BaseRepository<AccountEntity>, IAccountsRepository
    {
        private DbSet<AccountEntity> _dataset;

        public AccountsImplementation(MyContext context) : base(context)
        {

            _dataset = context.Set<AccountEntity>();
        }

        public async Task<AccountEntity> FindAccounts(string userMF)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.userMF.Equals(userMF));
        }
    }
}
