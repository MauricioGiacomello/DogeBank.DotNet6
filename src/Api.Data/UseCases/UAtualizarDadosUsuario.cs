using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases.Interfaces
{
    public class UAtualizarDadosUsuario : BaseRepository<UserEntity>, IUAtualizarDadosUsuario
    {
        private DbSet<UserEntity> _dataset;
        private BaseRepository<UserEntity> _baseRepository;

        public UAtualizarDadosUsuario(MyContext context, BaseRepository<UserEntity> baseRepository) : base(context)
        {
            _dataset = context.Set<UserEntity>();
            _baseRepository = baseRepository;

        }
        public async Task<UserEntity> FazerAtualizacoes(UserEntity dadosUsuario)
        {
            return await _baseRepository.UpdateAsync(dadosUsuario);
        }
    }
}
