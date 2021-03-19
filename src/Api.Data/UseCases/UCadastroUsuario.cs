using System;
using System.Net;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementation;
using Api.Data.Repository;
using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UserCases
{
    public class UCadastroUsuario : BaseRepository<UserEntity>, IUCadastroUsuario
    {
        private DbSet<UserEntity> _dataset;
        private IRepository<UserEntity> _repository;

        public UCadastroUsuario(MyContext context, IRepository<UserEntity> repository) : base(context)
        {
            _dataset = context.Set<UserEntity>();
            _repository = repository;
        }

        public async Task<UserEntity> RegistrarUsuario(UserEntity user)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(u => u.userMF.Equals(user.userMF));

                if (result != null)
                    return null;

                return await _repository.InsertAsync(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("userMF is invalid       : " + ex.Message);
                return null;
            }
        }
    }
}
