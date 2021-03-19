using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUObterDadosUsuario
    {
        Task<UserEntity> ObterUsuarioCPF(string cpf);
        Task<UserEntity> ObterUsuarioEmail(string email);

    }
}
