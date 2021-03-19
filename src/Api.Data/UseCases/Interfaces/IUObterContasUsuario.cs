using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUObterContasUsuario
    {
        Task<IEnumerable<AccountEntity>> BuscarContas(string usuario);

    }
}
