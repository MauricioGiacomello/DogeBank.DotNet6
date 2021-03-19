using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Api.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario
{
    public class RetornoCreate
    {
        private UsersController _controler;
        [Fact(DisplayName = "É possível realizar o Create")]
        public async System.Threading.Tasks.Task É_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var _serviceAdd = new Mock<IRegistrarUsuario>();
            var _obterUsuarioCpf = new Mock<IObterUsuarioCpfService>();
            var _atualizarDados = new Mock<IAtualizarDadosUsuarioService>();
            var _deletarDados = new Mock<IDeletarUsuarioService>();

            var _name = Faker.Name.FullName();
            var _userMf = Faker.Identification.UKNationalInsuranceNumber();

            _serviceAdd.Setup
                (m => m.UserRegister(It.IsAny<CadastroUsuarioRequest>()))
                                            .ReturnsAsync(new CadastroUsuarioResult
                                            {
                                                name = _name,
                                                userMF = _userMf,
                                                creatAt = DateTime.UtcNow
                                            });


            _controler = new UsersController
                (serviceMock.Object, _serviceAdd.Object,
                 _obterUsuarioCpf.Object, _atualizarDados.Object,
                 _deletarDados.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(),
                It.IsAny<object>())).Returns("http://localhost:5000");

            _controler.Url = url.Object;

            var usuarioCreate = new CadastroUsuarioRequest
            {
                name = _name,
                userMF = _userMf,
            };

            var result = await _controler.RegisterUser(usuarioCreate);

            Assert.True(result is CreatedResult);
        }
    }
}
