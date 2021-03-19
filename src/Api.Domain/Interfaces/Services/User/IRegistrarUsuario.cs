using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.User;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IRegistrarUsuario
    {
        Task<CadastroUsuarioResult> UserRegister(CadastroUsuarioRequest user);
    }
}
