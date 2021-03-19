using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.UseCases
{
    public class UObterContasUsuario : BaseRepository<AccountEntity>, IUObterContasUsuario
    {
        private DbSet<AccountEntity> _dataset;
        private BaseRepository<AccountEntity> _baseRepository;


        public UObterContasUsuario(MyContext context, BaseRepository<AccountEntity> baseRepository)
         : base(context)

        {
            _dataset = context.Set<AccountEntity>();
            _baseRepository = baseRepository;
        }
        public async Task<IEnumerable<AccountEntity>> BuscarContas(string cpf)
        {
            try
            {
                IEnumerable<AccountEntity> todasContas = await _baseRepository.SelectAsync();
                var result = todasContas.Where(c => c.userMF.Equals(cpf));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
