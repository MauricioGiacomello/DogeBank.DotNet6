using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases
{
    public class UObterDadosUsuario : BaseRepository<UserEntity>, IUObterDadosUsuario
    {
        private DbSet<UserEntity> _dataset;
        public UObterDadosUsuario(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }
        public async Task<UserEntity> ObterUsuarioCPF(string cpf)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.userMF == cpf);
        }
        public async Task<UserEntity> ObterUsuarioEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.email == email);
        }
    }
}
