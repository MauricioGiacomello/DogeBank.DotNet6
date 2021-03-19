using System.Threading.Tasks;
using Api.Domain.Models.User;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IDeletarUsuarioService
    {
        Task<bool> DeletarContaUsuario(DeletarUsuarioRequest user);
    }
}
