using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Api.Data.UserCases;
using Api.Domain.Dtos;
using Api.Service.Services;
using Api.Domain.Interfaces.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Api.Domain.Models;
using Api.Domain.Models.User;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _service;
        private IRegistrarUsuario _serviceAdd;
        private IObterUsuarioCpfService _obterDadosUsuario;
        private IAtualizarDadosUsuarioService _atualizarDados;
        private readonly IDeletarUsuarioService _deletarUsuario;

        public UsersController(IUserService service,
                               IRegistrarUsuario serviceAdd,
                               IObterUsuarioCpfService obterDadosUsuario,
                               IAtualizarDadosUsuarioService atualizarDados,
                               IDeletarUsuarioService deletarUsuario)
        {
            _service = service;
            _serviceAdd = serviceAdd;
            _obterDadosUsuario = obterDadosUsuario;
            _atualizarDados = atualizarDados;
            _deletarUsuario = deletarUsuario;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        public async Task<ActionResult> GetAll()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Devolve solicitação invalida //
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ObterUsuarioPorCpf")]
        public async Task<ActionResult> ObterUsuariosCPF([FromQuery] UsuarioRequest dadosUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _obterDadosUsuario.ObterDadosUsuarioCpf(dadosUsuario));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<ActionResult> RegisterUser([FromBody] CadastroUsuarioRequest usuario)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _serviceAdd.UserRegister(usuario);

                if (result != null)
                {

                    return Created(new Uri(Url.Link("ObterUsuarioCPF", new { ObterUsuarioPorCpf = result.userMF })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("AtualizarUsuario")]
        public async Task<ActionResult> AtualizarUsuario([FromBody] AtualizarDadosUsuarioRequest dadosUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _atualizarDados.AtualizaDadosUsuario(dadosUsuario);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete("DeletarUsuario")]
        public async Task<ActionResult> Delete([FromQuery] DeletarUsuarioRequest usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _deletarUsuario.DeletarContaUsuario(usuario));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

    }
}

