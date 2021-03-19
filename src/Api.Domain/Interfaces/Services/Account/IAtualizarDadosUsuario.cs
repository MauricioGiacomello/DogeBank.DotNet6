using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Models.User;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IAtualizarDadosUsuarioService
    {
        Task<AtualizarDadosUsuarioResult> AtualizaDadosUsuario(AtualizarDadosUsuarioRequest dadosConta);

    }
}
