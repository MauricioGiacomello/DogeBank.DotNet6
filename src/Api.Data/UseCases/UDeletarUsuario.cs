using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases
{
    public class UDeletarUsuario : BaseRepository<UserEntity>, IUDeletarUsuario
    {
        private DbSet<UserEntity> _dataset;
        public UDeletarUsuario(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }
        public async Task<UserEntity> ExcluirUsuario(UserEntity usuario)
        {
            try
            {
                _dataset.Remove(usuario);
                await _context.SaveChangesAsync();
                return usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

