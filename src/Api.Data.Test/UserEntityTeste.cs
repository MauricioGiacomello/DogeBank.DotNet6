using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.ControllersTest
{
    public class UserEntityTeste
    {
        private Mock<IUserService> _IUserService;
        private Mock<IRegistrarUsuario> _serviceAdd;
        private Mock<IObterUsuarioCpfService> _obterDadosUsuario;
        private Mock<IAtualizarDadosUsuarioService> _atualizarDados;
        private readonly Mock<IDeletarUsuarioService> _deletarUsuario;
        private readonly UsersController _userController;



        [Fact(DisplayName = "Get: Quando solicitado deveria retornar um lista de usuarios")]
        public async Task GetAll_quando_solicitado_retornar_lista_de_usuarios()
        {
            //Arrange
            var listaUsuarios = new List<UserEntity>();

            UserEntity usuario1 = new UserEntity
            {
                name = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                userMF = Faker.Identification.UKNationalInsuranceNumber(),
            };

            UserEntity usuario2 = new UserEntity
            {
                name = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                userMF = Faker.Identification.UKNationalInsuranceNumber(),
            };

            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);

            var mockDatabase = new Mock<IRepository<UserEntity>>();
            mockDatabase.Setup(t => t.SelectAsync()).ReturnsAsync(new List<UserEntity>(
            ));

            mockDatabase.Setup(t => t.SelectAsync()).ReturnsAsync(listaUsuarios);

            // var service = new UsersController
            //                 (_IUserService.Object,
            //                 _serviceAdd.Object,
            //                 _obterDadosUsuario.Object,
            //                 _atualizarDados.Object,
            //                 _deletarUsuario.Object);

            var result = await _userController.GetAll();


            //Assert
            Assert.NotNull(result);
        }
    }
}
