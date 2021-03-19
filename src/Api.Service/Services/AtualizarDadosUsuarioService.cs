using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.UseCases;
using Api.Data.UseCases.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    public class AtualizarDadosUsuarioService : IAtualizarDadosUsuarioService
    {
        private IUObterDadosUsuario _usuario;
        private IUAtualizarDadosUsuario _atualizarDadosUsuario;
        private readonly IMapper _mapper;

        public AtualizarDadosUsuarioService(IUObterDadosUsuario usuario,
                                            IUAtualizarDadosUsuario atualizarDadosUsuario,
                                            IMapper mapper)
        {
            _usuario = usuario;
            _atualizarDadosUsuario = atualizarDadosUsuario;
            _mapper = mapper;
        }
        public async Task<AtualizarDadosUsuarioResult> AtualizaDadosUsuario(AtualizarDadosUsuarioRequest dadosConta)
        {
            try
            {
                var resultUsuario = await _usuario.ObterUsuarioCPF(dadosConta.odlUserMf);

                if (resultUsuario != null)
                {
                    var result = _mapper.Map<UserEntity>(dadosConta);
                    result.Id = resultUsuario.Id;
                    result = await _atualizarDadosUsuario.FazerAtualizacoes(result);
                    return _mapper.Map<AtualizarDadosUsuarioResult>(result);
                }

                return null;
            }

            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
