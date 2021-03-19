using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models.User;

namespace Api.Data.UserCases.Interfaces
{
    public interface IUCadastroUsuario
    {
        Task<UserEntity> RegistrarUsuario(UserEntity user);

    }
}
