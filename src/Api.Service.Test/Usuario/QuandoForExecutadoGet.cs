using System.Threading.Tasks;
using Api.Data.UseCases.Interfaces;
using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Models;
using Api.Domain.Models.User;
using Api.Service.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : BaseTestService
    {
        private Mock<IUObterDadosUsuario> _IUObterDadosUsuario;
        private Mock<IUCadastroUsuario> _IUCadastroUsuario; 
        private Mock<IUObterContasUsuario> _IUObterContasUsuario;
        private Mock<IUAtualizarDadosUsuario> _IUAtualizarDadosUsuario;
        private Mock<IAtualizarDadosUsuarioService> _IAtualizarDadosUsuarioService;
        
        private Mock<IRepository<UserEntity>> _Irepository;


               public async System.Threading.Tasks.Task TestarIObterUsuarioCpfServiceAsync()
        {
            _IUObterDadosUsuario = new Mock<IUObterDadosUsuario>();
            _Irepository = new Mock<IRepository<UserEntity>>();
            var teste2 = new UsuarioTestes();

            _IUObterDadosUsuario.Setup
                (m => m.ObterUsuarioCPF(teste2._usuarioRequest.userMf)).ReturnsAsync(new UserEntity()
                {
                    userMF = teste2._usuarioResult.userMf,
                    name = teste2._usuarioResult.name
                });

            var service = new ObterUsuarioCpfService(_IUObterDadosUsuario.Object, _Irepository.Object, Mapper);
            var result = await service.ObterDadosUsuarioCpf(teste2._usuarioRequest);

            Assert.NotNull(result);
            Assert.True(result.userMf == teste2._usuarioResult.userMf);
            Assert.Equal(result.name, teste2._usuarioResult.name);
        }

        [Fact]
        public async Task TestarUObterDadosAtualizacaoContaAsync()
        {
            _IUCadastroUsuario = new Mock<IUCadastroUsuario>();
            _Irepository = new Mock<IRepository<UserEntity>>();

            var usuarioFake = new UserEntity();

            _IUCadastroUsuario.Setup
                (u => u.RegistrarUsuario(usuarioFake)).ReturnsAsync(new UserEntity()
                {
                    name = usuarioFake.name,
                    nameMother = usuarioFake.nameMother,
                    nameFather = usuarioFake.nameFather,
                    email = usuarioFake.email,
                    userMF = usuarioFake.userMF,
                    CreateAt = usuarioFake.CreateAt,
                    UpdateAt = usuarioFake.UpdateAt
                });

            var service = new RegistrarUsuario(_IUCadastroUsuario.Object, Mapper);
            var resultCoversao = Mapper.Map<CadastroUsuarioRequest>(usuarioFake); //EDITAR//

            var result = await service.UserRegister(resultCoversao);

            Assert.NotNull(result);
            Assert.True(result.userMF == usuarioFake.name);
            Assert.True(result.name == usuarioFake.name);
            Assert.True(result.nameMother == usuarioFake.nameMother);
        }///////////////////////// FALHAR TESTE////////////////////////////
        ///                        CRIAR REGRESSÃO /////
        ///                        TEST COBERTURA BAIXA ////

        [Fact]
        public async Task TestarAtualizarDadosUsuarioService()
        {
            _IAtualizarDadosUsuarioService = new Mock<IAtualizarDadosUsuarioService>();
            _IUObterDadosUsuario = new Mock<IUObterDadosUsuario>();
            _IUObterContasUsuario = new Mock<IUObterContasUsuario>();
            _IUAtualizarDadosUsuario = new Mock<IUAtualizarDadosUsuario>();

            var usuarioFake = new UsuarioTestes();

            _IUObterDadosUsuario.Setup(m => m.ObterUsuarioCPF(usuarioFake._atualizarDadosUsuarioRequest.odlUserMf)).ReturnsAsync(new UserEntity()
            {
                userMF = usuarioFake._atualizarDadosUsuarioRequest.userMf,
                name = usuarioFake._atualizarDadosUsuarioRequest.name,
                nameMother = usuarioFake._atualizarDadosUsuarioRequest.nameMother,
                nameFather = usuarioFake._atualizarDadosUsuarioRequest.nameFather,
                email = usuarioFake._atualizarDadosUsuarioRequest.email,
            });

            var resultConversao = Mapper.Map<UserEntity>(usuarioFake._atualizarDadosUsuarioRequest);

            _IUAtualizarDadosUsuario.Setup(m => m.FazerAtualizacoes(resultConversao)).ReturnsAsync(new UserEntity()
            {
                name = resultConversao.name,
                nameMother = resultConversao.nameMother,
                nameFather = resultConversao.nameFather,
                email = resultConversao.email,
                userMF = resultConversao.userMF,
                CreateAt = resultConversao.CreateAt,
                UpdateAt = resultConversao.UpdateAt
            });

            //  _IUAtualizarDadosUsuario.Setup(m => m.FazerAtualizacoes.)

            var service = new AtualizarDadosUsuarioService
                (_IUObterDadosUsuario.Object, _IUAtualizarDadosUsuario.Object, Mapper);

            var resultTipoRequest = Mapper.Map<AtualizarDadosUsuarioRequest>(resultConversao);
            resultTipoRequest.odlUserMf = usuarioFake._atualizarDadosUsuarioRequest.odlUserMf;
            var result = await service.AtualizaDadosUsuario(resultTipoRequest);

            Assert.NotNull(result);
            Assert.True(result.userMf == resultConversao.userMF);
            Assert.True(result.name == resultConversao.name);
            Assert.True(result.nameMother == resultConversao.nameMother);


        }
    }
}
