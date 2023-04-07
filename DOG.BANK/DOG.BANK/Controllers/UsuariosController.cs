using DOB.ApiDotNet6.Api.Models.ViewModels;
using DOB.ApiDotNet6.Domain.Models;
using DOB.ApiDotNet6.Infra.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOB.ApiDotNet6.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ProdutoServices _produtoService;

        public UsuariosController(ProdutoServices produtoService)
        {
            _produtoService = produtoService;
        }

        [Route("ObterUsuarios")]
        [HttpGet]
        public async Task<List<Usuario>> ObterUsuario() 
        {
            var result = await _produtoService.GetAsync();
            return result;
        }   

        [Route("ObterUsuario")]
        [HttpGet]
        public async Task<Usuario> ObterUsuarios(string id)
        {
            var result = await _produtoService.GetAsync(id);
            return result;
        }

        [Route("CadastrarUsuario")]
        [HttpPost]
        public async Task AtualizarUsuario(UsuarioViewModel request)
        {
            Usuario usuario = new Usuario() { 
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Rg = request.Rg,
                Cpf = request.Cpf
            };

            await _produtoService.CreateAsync(usuario);
        }

        [Route("AtualizarUsuario")]
        [HttpPut]
        public List<string> AtualizarUsuario()
        {
            var result = new List<string>();

            var usuario = "Mauricio de Souza";
            var idade = "23";

            result.Add(usuario);
            result.Add(idade);

            return result;
        }

        [Route("DeletarUsuario")]
        [HttpDelete]
        public async Task ExcluirUsuario(string id)
        {
            await _produtoService.RemoveAsync(id);

        }
    }
}
