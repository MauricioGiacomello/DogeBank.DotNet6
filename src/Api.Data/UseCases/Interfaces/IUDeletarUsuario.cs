using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.UseCases.Interfaces
{
    public interface IUDeletarUsuario
    {
        Task<UserEntity> ExcluirUsuario(UserEntity usuario);

    }
}
