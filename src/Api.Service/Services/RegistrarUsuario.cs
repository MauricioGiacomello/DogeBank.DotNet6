using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.UserCases;
using Api.Data.UserCases.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    public class RegistrarUsuario : IRegistrarUsuario
    {
        private IUCadastroUsuario _register;
        private readonly IMapper _mapper;

        public RegistrarUsuario(IUCadastroUsuario register, IMapper mapper)
        {
            _register = register;
            _mapper = mapper;
        }

        public async Task<CadastroUsuarioResult> UserRegister(CadastroUsuarioRequest user)
        {
            var result = _mapper.Map<UserEntity>(user);
            await _register.RegistrarUsuario(result);
            return _mapper.Map<CadastroUsuarioResult>(result);
        }
    }
}
