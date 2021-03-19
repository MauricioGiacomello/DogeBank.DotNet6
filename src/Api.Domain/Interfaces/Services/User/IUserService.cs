using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UsuarioRequest> Get(Guid id); //Busca um user entity pela Guid//
        Task<IEnumerable<UsuarioResult>> GetAll(); //Lista com todos os usuarios //
        Task<UsuarioCreateResult> Post(UsuarioRequest user); //Recebo um usuario e devolvo o usuario//
        Task<UsuarioUpdateResult> Put(UsuarioRequest user); //Recebe user entity e faz a atualização//
        Task<bool> Delete(Guid id); // Deleta o usuario pelo UserEntity//
    }
}
