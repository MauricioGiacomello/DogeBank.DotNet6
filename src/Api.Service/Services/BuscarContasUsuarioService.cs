using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;

namespace Api.Service.Services
{
    public class BuscarContasUsuarioService : IBuscarContasUsuarioService
    {
        private UObterContasUsuario _obterContasUsuario;

        public BuscarContasUsuarioService(UObterContasUsuario obterContasUsuario)
        {
            _obterContasUsuario = obterContasUsuario;
        }
        public async Task<IEnumerable<AccountEntity>> ObeterContasUsuario(ContasUsuarioRequest usuario)
        {
            var result = await _obterContasUsuario.BuscarContas(usuario.cpf);
            return result;
        }
    }
}
