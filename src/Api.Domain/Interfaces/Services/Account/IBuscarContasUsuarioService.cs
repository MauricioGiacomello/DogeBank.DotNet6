using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IBuscarContasUsuarioService
    {
        Task<IEnumerable<AccountEntity>> ObeterContasUsuario(ContasUsuarioRequest usuario);

    }
}
