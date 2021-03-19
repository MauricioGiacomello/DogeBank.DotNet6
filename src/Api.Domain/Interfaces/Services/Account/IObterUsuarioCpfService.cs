using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IObterUsuarioCpfService
    {
        Task<UsuarioResult> ObterDadosUsuarioCpf(UsuarioRequest dadosUsuario);
    }
}
