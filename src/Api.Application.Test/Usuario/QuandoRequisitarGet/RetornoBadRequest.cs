using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGet
{
    public class RetornoBadRequest
    {
        private UsersController _controler;
        [Fact(DisplayName = "É possível realizar o Get")]
        public async System.Threading.Tasks.Task É_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var _serviceAdd = new Mock<IRegistrarUsuario>();
            var _obterUsuarioCpf = new Mock<IObterUsuarioCpfService>();
            var _atualizarDados = new Mock<IAtualizarDadosUsuarioService>();
            var _deletarDados = new Mock<IDeletarUsuarioService>();

            var _name = Faker.Name.FullName();
            var _userMf = Faker.Identification.UKNationalInsuranceNumber();

            _obterUsuarioCpf.Setup
                (m => m.ObterDadosUsuarioCpf(It.IsAny<UsuarioRequest>()))
                                            .ReturnsAsync(new UsuarioResult
                                            {
                                                name = _name,
                                                userMf = _userMf,
                                            });

            _controler = new UsersController
                (serviceMock.Object, _serviceAdd.Object,
                 _obterUsuarioCpf.Object, _atualizarDados.Object,
                 _deletarDados.Object);

            _controler.ModelState.AddModelError("Id", "Formato Inválido");

            var usuarioBuscado = new UsuarioRequest
            {
                Name = _name,
                userMf = _userMf
            };

            var result = await _controler.ObterUsuariosCPF(usuarioBuscado);

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
