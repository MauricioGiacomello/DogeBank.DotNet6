using System.Threading.Tasks;

namespace Api.Integration.Test.Usuario
{
    public class TesteLogin : BaseIntegration
    {
        public async Task TesteDoToken()
        {
            await AdicionarToken();
        }
    }
}
