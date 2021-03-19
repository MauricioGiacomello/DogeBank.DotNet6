using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Entities;
using AutoMapper;
using EstudoAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; set; }
        public HttpClient client { get; set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "https://localhost:5001/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();
            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginRequest = new AcessoRequest()
            {
                email = "teste75@teste75.com"
            };
            var resultLogin = await PostJsonAsync(loginRequest, $"{hostApi}Login", client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseRequest>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.acessToken);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.Authentication("Baarer", loginObject.acessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync
                (url, new StringContent(JsonConvert.SerializeObject(dataclass),
                     System.Text.Encoding.UTF8, "application/json"));
        }
        public class AutoMapperFixture : IDisposable
        {
            public void Dispose()
            {
            }

            public IMapper GetMapper()
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new RequestToModelProfile());
                    cfg.AddProfile(new EntityToRequestProfile());
                });

                return config.CreateMapper();
            }
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }
}
