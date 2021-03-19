using System;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    public class DeletarUsuarioService : IDeletarUsuarioService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        private readonly UObterDadosUsuario _obterUsuario;
        private readonly UDeletarUsuario _deletarUsuario;

        public DeletarUsuarioService(IRepository<UserEntity> repository,
                                     IMapper mapper,
                                     UObterDadosUsuario obterUsuario,
                                     UDeletarUsuario deletarUsuario)
        {
            _repository = repository;
            _mapper = mapper;
            _obterUsuario = obterUsuario;
            _deletarUsuario = deletarUsuario;
        }
        public async Task<bool> DeletarContaUsuario(DeletarUsuarioRequest user)
        {
            try
            {
                UserEntity result = await _obterUsuario.ObterUsuarioCPF(user.userMf);

                if (result == null)
                {
                    return false;
                }

                await _deletarUsuario.ExcluirUsuario(result);
                return true;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
