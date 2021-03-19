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
    public class UObterUsuario : BaseRepository<UserEntity>, IUObterUsuario
    {
        private DbSet<UserEntity> _dataset;
        private IRepository<UserEntity> _repository;

        public UObterUsuario(MyContext context, IRepository<UserEntity> repository) : base(context)
        {
            _dataset = context.Set<UserEntity>();
            _repository = repository;
        }

        public async Task<AccountEntity> BuscarUsuario(CriarContaBancariaRequest usuario)
        {
            var result = await _dataset.FirstOrDefaultAsync(u => u.email.Equals(usuario.email));

            if (result != null)
            {
                AccountEntity _usuario = new AccountEntity();
                _usuario.userMF = usuario.cpf;
                return _usuario;
            }

            return null;

        }
    }
}
