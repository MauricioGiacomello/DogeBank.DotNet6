using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IAccountUserService _accountService;
        private ITransferenciaService _servicoTransferencia;
        private ICriarContaService _contaBancaria;
        private IBuscarContasUsuarioService _contasUsuario;
        private IAtualizarDadosService _atulizaDados;
        private ISaqueService _fazerSaque;
        private IDepositoService _fazerDeposito;

        public AccountsController(IAccountUserService accountService,
                                  ITransferenciaService servicoTransferencia,
                                  ICriarContaService contaBancaria,
                                  IBuscarContasUsuarioService contasUsuario,
                                  IAtualizarDadosService atulizaDados,
                                  ISaqueService fazerSaque,
                                  IDepositoService fazerDeposito)
        {
            _accountService = accountService;
            _servicoTransferencia = servicoTransferencia;
            _contaBancaria = contaBancaria;
            _contasUsuario = contasUsuario;
            _atulizaDados = atulizaDados;
            _fazerSaque = fazerSaque;
            _fazerDeposito = fazerDeposito;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("TodasContasBanco")]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Devolve solicitação invalida //
            }
            try
            {
                return Ok(await _accountService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("ContasBancoPorId", Name = "ContasBancoPorIds")]

        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Devolve solicitação invalida //
            }

            try
            {
                return Ok(await _accountService.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("TodasContasUsuario")]
        public async Task<ActionResult> ContasDoUsuario([FromQuery] ContasUsuarioRequest usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Devolve solicitação invalida //
            }

            try
            {
                return Ok(await _contasUsuario.ObeterContasUsuario(usuario));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("CriarContaBancaria")]
        public async Task<ActionResult> CriarContaBancaria([FromBody] CriarContaBancariaRequest dadosConta)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _contaBancaria.CriarContaBanc(dadosConta);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("ContasBancoPorIds", new { ContasBancoPorId = result.Id })), result);
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

        [Authorize("Bearer")]
        [HttpPut]
        [Route("TransferenciaContas")]
        public async Task<ActionResult> AccountTransfer([FromBody] TransferenciaContasEntity contas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _servicoTransferencia.BuscarContas(contas);
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

        [Authorize("Bearer")]
        [HttpPut]
        [Route("Saque")]
        public async Task<ActionResult> Saque([FromBody] SolicitacaoSaqueRequest dadosConta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _fazerSaque.Saque(dadosConta);
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

        [Authorize("Bearer")]
        [HttpPut]
        [Route("Deposito")]
        public async Task<ActionResult> Deposito([FromBody] SolicitacaoDepositoRequest dadosConta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _fazerDeposito.Deposito(dadosConta);
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

        [Authorize("Bearer")]
        [HttpPut]
        [Route("AtualizarDadosConta")]
        public async Task<ActionResult> AtualizarDadosConta([FromBody] DadosAtualizacaoContaRequest dadosConta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _atulizaDados.VerificarAtualizarConta(dadosConta);
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

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("DeletarConta")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _accountService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}

