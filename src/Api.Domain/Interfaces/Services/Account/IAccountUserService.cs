using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IAccountUserService 
    {
        Task<AccountEntity> Get(Guid id);
        Task<IEnumerable<AccountEntity>> GetAll();
        Task<AccountEntity> Post(AccountEntity Accounts);
        Task<AccountEntity> Put(AccountEntity Accounts);
        Task<bool> Delete(Guid id);
    }
}

