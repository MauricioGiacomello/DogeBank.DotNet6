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
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {

                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    name = Faker.Name.FullName(),
                    nameMother = Faker.Name.FullName(),
                    nameFather = Faker.Name.FullName(),
                    email = Faker.Internet.Email(),
                    userMF = Faker.Identification.UKNationalInsuranceNumber()
                };

                UserEntity _entity2 = new UserEntity
                {
                    name = Faker.Name.FullName(),
                    nameMother = Faker.Name.FullName(),
                    nameFather = Faker.Name.FullName(),
                    email = Faker.Internet.Email(),
                    userMF = Faker.Identification.UKNationalInsuranceNumber()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                var _registroCriado2 = await _repositorio.InsertAsync(_entity2);


                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.email, _registroCriado.email);
                Assert.Equal(_entity.name, _registroCriado.name);
                Assert.Equal(_entity.nameMother, _registroCriado.nameMother);
                Assert.Equal(_entity.nameFather, _registroCriado.nameFather);
                Assert.Equal(_entity.userMF, _registroCriado.userMF);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.email, _registroCriado.email);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste); // Retorna true of False

                var _selecionarUsuario = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.Equal(_selecionarUsuario.Id, _registroAtualizado.Id);

                IEnumerable<UserEntity> _selecionarTodosUsuario = await _repositorio.SelectAsync();
                Assert.NotNull(_selecionarTodosUsuario);

                var _excluirConta = await _repositorio.DeleteAsync(_registroAtualizado.Id);
                Assert.True(_excluirConta);
            }
        }
    }
}
