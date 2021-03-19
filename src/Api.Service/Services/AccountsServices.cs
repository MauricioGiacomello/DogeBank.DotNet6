using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class AccountsService : IAccountUserService
    {
        private IRepository<AccountEntity> _repository;

        public AccountsService(IRepository<AccountEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AccountEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<AccountEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<AccountEntity> Post(AccountEntity Accounts)
        {
            return await _repository.InsertAsync(Accounts);
        }

        public async Task<AccountEntity> Put(AccountEntity Accounts)
        {
            return await _repository.UpdateAsync(Accounts);
        }
    }
}
