using System;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UserCases;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;

namespace Api.Service.Services
{
    public class CriarContaService : ICriarContaService
    {
        private UObterUsuario _usuarioExistente;
        private UCriarContaBanc _criarConta;

        public CriarContaService(UObterUsuario usuarioExistente, UCriarContaBanc criarConta)
        {
            _usuarioExistente = usuarioExistente;
            _criarConta = criarConta;
        }

        public async Task<AccountEntity> CriarContaBanc(CriarContaBancariaRequest dadosConta)
        {
            var result = await _usuarioExistente.BuscarUsuario(dadosConta);

            if (result != null)
            {
                return await _criarConta.FiltarDadosCriar(dadosConta);

            }
            else
            {
                Console.WriteLine("Usuario não encontrado       : ");
                return null;
            }
        }
    }
}
