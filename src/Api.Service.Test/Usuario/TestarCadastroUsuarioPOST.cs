using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;

using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class TestMetodoGetAllUsuarios
    {
        private IUDepositoSaque _IUDepositoSaque;

        private Mock<IUDepositoSaque> _IUDepositoSaqueMock;

        [Fact]
        public void TestarDeposito()
        {
            _IUDepositoSaqueMock = new Mock<IUDepositoSaque>();


            AccountEntity Creditado = new AccountEntity()
            {
                accountNumber = 3,
                balanceCredit = 1000,
                userMF = "999888"
            };

            double valorDeposito = 1000;


            _IUDepositoSaqueMock = new Mock<IUDepositoSaque>();
            //_IUDepositoSaqueMock.Setup
            //     (c => c.Deposito (Creditado, valorDeposito)).ReturnsAsync(new UserEntity){

            // };

            //  _IUObterDadosUsuario.Setup
            //     (m => m.ObterUsuarioCPF(teste2._usuarioRequest.userMf)).ReturnsAsync(new UserEntity()
            //     {
            //         userMF = teste2._usuarioResult.userMf,
            //         name = teste2._usuarioResult.name
            //     });

        }
    }
}
