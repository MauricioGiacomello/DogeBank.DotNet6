using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.User;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string UserMf { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UsuarioRequest> listaUsuarioRequest = new List<UsuarioRequest>();
        public UsuarioRequest _usuarioRequest;
        public UsuarioResult _usuarioResult;
        public CadastroUsuarioRequest _cadastroUsuarioRequest;
        public CadastroUsuarioResult _cadastroUsuarioResult;
        public AtualizarDadosUsuarioRequest _atualizarDadosUsuarioRequest;
        public AtualizarDadosUsuarioResult _atualizarDadosUsuarioResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            UserMf = Faker.Identification.UKNationalInsuranceNumber();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; ++i)
            {
                var usuario = new UsuarioRequest()
                {
                    Name = Faker.Name.FullName(),
                    userMf = Faker.Internet.Email()
                };
                listaUsuarioRequest.Add(usuario);
            }

            _usuarioRequest = new UsuarioRequest
            {
                Name = Faker.Name.FullName(),
                userMf = Faker.Identification.UKNationalInsuranceNumber()
            };

            _usuarioResult = new UsuarioResult
            {
                name = Faker.Name.FullName(),
                userMf = Faker.Internet.Email()
            };

            _cadastroUsuarioRequest = new CadastroUsuarioRequest
            {
                name = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                email = Faker.Internet.Email(),
                userMF = Faker.Identification.UKNationalInsuranceNumber()
            };

            _cadastroUsuarioResult = new CadastroUsuarioResult
            {
                name = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                email = Faker.Internet.Email(),
                userMF = Faker.Identification.UKNationalInsuranceNumber(),
                creatAt = DateTime.UtcNow
            };

            _atualizarDadosUsuarioRequest = new AtualizarDadosUsuarioRequest
            {
                name = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                email = Faker.Internet.Email(),
                userMf = Faker.Identification.UKNationalInsuranceNumber(),
                odlUserMf = ("999999999")
            };

            _atualizarDadosUsuarioResult = new AtualizarDadosUsuarioResult
            {
                name = Faker.Name.FullName(),
                nameMother = Faker.Name.FullName(),
                nameFather = Faker.Name.FullName(),
                email = Faker.Internet.Email(),
                userMf = Faker.Identification.UKNationalInsuranceNumber(),
            };
        }


    }
}
