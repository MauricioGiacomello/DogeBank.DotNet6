using System;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Api.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class RetornoBadRequest
    {
        private UsersController _controler;
        [Fact(DisplayName = "É possível realizar o Create")]
        public async System.Threading.Tasks.Task É_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var _serviceAdd = new Mock<IRegistrarUsuario>();
            var _obterUsuarioCpf = new Mock<IObterUsuarioCpfService>();
            var _atualizarDados = new Mock<IAtualizarDadosUsuarioService>();
            var _deletarDados = new Mock<IDeletarUsuarioService>();

            var _name = Faker.Name.FullName();
            var _userMf = Faker.Identification.UKNationalInsuranceNumber();

            _atualizarDados.Setup // Mockando _atualizarDados para que já tenha o resultado //
                (m => m.AtualizaDadosUsuario(It.IsAny<AtualizarDadosUsuarioRequest>()))
                                            .ReturnsAsync(new AtualizarDadosUsuarioResult
                                            {
                                                name = _name,
                                                userMf = _userMf,
                                            });

            var usuarioUpdate = new AtualizarDadosUsuarioRequest
            { //Usuario de testes//
                name = _name,
                userMf = _userMf,
            };

            _controler = new UsersController
                (serviceMock.Object, _serviceAdd.Object,
                 _obterUsuarioCpf.Object, _atualizarDados.Object,
                 _deletarDados.Object);

            _controler.ModelState.AddModelError("email", "Campo Obrigatório!");

            var result = await _controler.AtualizarUsuario(usuarioUpdate);//Chamando a controler//
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controler.ModelState.IsValid);
        }
    }
}
