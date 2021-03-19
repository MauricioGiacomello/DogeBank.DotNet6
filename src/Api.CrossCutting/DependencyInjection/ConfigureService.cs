using Api.Data.Implementation;
using Api.Data.Repository;
using Api.Data.UseCases;
using Api.Data.UseCases.Interfaces;
using Api.Data.UserCases;
using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Security.Interfaces;
using Api.Service.Services;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IRegistrarUsuario, RegistrarUsuario>();
            serviceCollection.AddTransient<ITransferenciaService, TransferenciaService>();
            serviceCollection.AddTransient<IAccountUserService, AccountsService>();
            serviceCollection.AddTransient<IUDepositoSaque, UDepositoSaque>();
            serviceCollection.AddTransient<IUserRepository, UserImplementation>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<ICriarContaService, CriarContaService>();
            serviceCollection.AddTransient<IUCriarContaBanc, UCriarContaBanc>();
            serviceCollection.AddTransient<IUObterUsuario, UObterUsuario>();
            serviceCollection.AddTransient<IBuscarContasUsuarioService, BuscarContasUsuarioService>();
            serviceCollection.AddTransient<IAtualizarDadosService, AtualizarDadosService>();
            serviceCollection.AddTransient<ISaqueService, SaqueService>();
            serviceCollection.AddTransient<IDepositoService, DepositoService>();
            serviceCollection.AddTransient<IObterUsuarioCpfService, ObterUsuarioCpfService>();
            serviceCollection.AddTransient<IAtualizarDadosUsuarioService, AtualizarDadosUsuarioService>();
            serviceCollection.AddTransient<IDeletarUsuarioService, DeletarUsuarioService>();
            serviceCollection.AddTransient<IUCadastroUsuario, UCadastroUsuario>();
            serviceCollection.AddTransient<IUObterDadosUsuario, UObterDadosUsuario>();
            serviceCollection.AddTransient<IUAtualizarDadosUsuario, UAtualizarDadosUsuario>();

            serviceCollection.AddTransient<SolicitacaoSaqueDeposito>();
            serviceCollection.AddTransient<TransferenciaContasEntity>();
            serviceCollection.AddTransient<UDepositoSaque>();
            //serviceCollection.AddTransient<UCadastroUsuario>();
            serviceCollection.AddTransient<UObterUsuario>();
            serviceCollection.AddTransient<CriarContaService>();
            serviceCollection.AddTransient<UCriarContaBanc>();
            serviceCollection.AddTransient<BaseRepository<AccountEntity>>();
            serviceCollection.AddTransient<BaseRepository<UserEntity>>();
            serviceCollection.AddTransient<UObterContasUsuario>();
            serviceCollection.AddTransient<UObterDadosAtualizacaoConta>();
            serviceCollection.AddTransient<UObterDadosConta>();
            serviceCollection.AddTransient<UObterDadosUsuario>();
            serviceCollection.AddTransient<UAtualizarDadosUsuario>();
            serviceCollection.AddTransient<UDeletarUsuario>();



















        }
    }
}
