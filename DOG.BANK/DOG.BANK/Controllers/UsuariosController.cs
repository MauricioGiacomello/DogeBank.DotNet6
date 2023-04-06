using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace DOB.ApiDotNet6.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet(Name = "Usuarios")]
        public string ObterUsuarios() 
        {
            var usuario = "Mauricio de Souza";

            return usuario;
        }
    }
}
