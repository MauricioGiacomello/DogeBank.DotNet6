using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IAccountsRepository : IRepository<AccountEntity>
    {
        Task<AccountEntity> FindAccounts(string userMF);
    }
}
