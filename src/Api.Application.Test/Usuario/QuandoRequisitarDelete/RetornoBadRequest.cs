using System;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Api.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class RetornoBadRequest
    {
        private UsersController _controler;
        [Fact(DisplayName = "É possível realizar o deleted")]
        public async System.Threading.Tasks.Task É_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            var _serviceAdd = new Mock<IRegistrarUsuario>();
            var _obterUsuarioCpf = new Mock<IObterUsuarioCpfService>();
            var _atualizarDados = new Mock<IAtualizarDadosUsuarioService>();
            var _deletarDados = new Mock<IDeletarUsuarioService>();

            var _usuario = new DeletarUsuarioRequest()
            {
                userMf = Faker.Identification.UKNationalInsuranceNumber()
            };

            _deletarDados.Setup // Mockando _atualizarDados para que já tenha o resultado //
                (m => m.DeletarContaUsuario(It.IsAny<DeletarUsuarioRequest>()))
                                            .ReturnsAsync(false);

            _controler = new UsersController
                (serviceMock.Object, _serviceAdd.Object,
                 _obterUsuarioCpf.Object, _atualizarDados.Object,
                 _deletarDados.Object);

            _controler.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controler.Delete(_usuario);//Chamando a controler//
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controler.ModelState.IsValid);
        }
    }
}
