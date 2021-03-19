using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ObterUsuarioCpfService : IObterUsuarioCpfService
    {
        private IUObterDadosUsuario _obterDados;
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public ObterUsuarioCpfService(IUObterDadosUsuario obterDados,
                                      IRepository<UserEntity> repository,
                                      IMapper mapper)
        {
            _obterDados = obterDados;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UsuarioResult> ObterDadosUsuarioCpf(UsuarioRequest dadosUsuario)
        {
            UserEntity result = await _obterDados.ObterUsuarioCPF(dadosUsuario.userMf);
            return _mapper.Map<UsuarioResult>(result);
        }
    }
}
