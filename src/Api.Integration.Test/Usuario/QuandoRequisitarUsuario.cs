using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Models.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        public string _name { get; set; }
        public string _userMf { get; set; }        
        public string _nameMother { get; set; }
        public string _nameFather { get; set; }
        public string _email { get; set; }

        [Fact]
        public async Task PossivelRealizarCRUDusuario()
        {
            await AdicionarToken();
            _name = Faker.Name.FullName();
            _nameMother = Faker.Name.FullName();
            _nameFather = Faker.Name.FullName();
            _email = Faker.Internet.Email();
            _userMf = Faker.Identification.UKNationalInsuranceNumber();

            var usuarioToCreate = new CadastroUsuarioRequest()
            {
                name = _name,
                nameFather = _nameFather,
                nameMother = _nameMother,
                email = _email,
                userMF = _userMf
            };

            //Post
            var response = await PostJsonAsync(usuarioToCreate, $"{hostApi}Users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CadastroUsuarioResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.name);
            Assert.True(registroPost.nameMother != default(string));

            //GetAll
            response = await client.GetAsync($"{hostApi}Users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UsuarioRequest>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.userMf == registroPost.userMF).Count() == 1); // Só tem 1 registro //

            //Put
            var updateUsuario = new AtualizarDadosUsuarioRequest()
            {
                name = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName()
            };

            //var stringContent = new StringContent(JsonConvert.DeserializeObject(updateUsuario),
              //  Encoding.UTF8, "application/json");

        }
    }
}
