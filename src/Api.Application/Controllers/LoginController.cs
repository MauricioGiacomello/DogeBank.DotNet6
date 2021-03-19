using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace Api.Application.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Acesso([FromBody] AcessoRequest dadosAcesso, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid || dadosAcesso == null)
                return BadRequest(ModelState);

            try
            {
                var result = await service.BuscarAcesso(dadosAcesso);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
