using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementation;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Api.Data.Test.BaseTest;

namespace Api.Data.Test
{
    public class ContasCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public ContasCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "AccountEntity")]
        public async Task Possivel_Realizar_CRUD_Contas()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {

                AccountsImplementation _repositorio = new AccountsImplementation(context);
                AccountEntity _entity = new AccountEntity
                {

                    accountType = ("poupanca"),
                    balanceCredit = Faker.RandomNumber.Next(),
                    accountNumber = Faker.RandomNumber.Next(),
                    userMF = Faker.Identification.UKNationalInsuranceNumber()
                };

                AccountEntity _entity2 = new AccountEntity
                {
                    accountType = ("corrente"),
                    balanceCredit = Faker.RandomNumber.Next(),
                    accountNumber = Faker.RandomNumber.Next(),
                    userMF = Faker.Identification.UKNationalInsuranceNumber()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                var _registroCriado2 = await _repositorio.InsertAsync(_entity2);


                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.accountNumber, _registroCriado.accountNumber);
                Assert.Equal(_entity.balanceCredit, _registroCriado.balanceCredit);
                Assert.Equal(_entity.accountType, ("poupanca"));
                Assert.Equal(_entity.userMF, _registroCriado.userMF);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.accountType = ("corrente");
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.accountType, ("corrente"));

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste); // Retorna true of False

                var _selecionarConta = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.Equal(_selecionarConta.Id, _registroAtualizado.Id);

                IEnumerable<AccountEntity> _selecionarTodosUsuario = await _repositorio.SelectAsync();
                Assert.NotNull(_selecionarTodosUsuario);

                var _excluirConta = await _repositorio.DeleteAsync(_registroAtualizado.Id);
                Assert.True(_excluirConta);
            }
        }
    }
}
