using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        //private TokenConfiguracao _tokenConfigurations;
        //    private IConfiguration _configuration { get; }

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations
                            )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            //_configuration = configuration;
        }
        public async Task<object> BuscarAcesso(AcessoRequest dadosAcesso)
        {
            var baseUser = new UserEntity();
            if (dadosAcesso != null && !string.IsNullOrWhiteSpace(dadosAcesso.email))
            {
                baseUser = await _repository.BuscarAcessoEmail(dadosAcesso.email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.email),
                        new[]
                        {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti O id do token
                    new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.email),
                        }
                    );
                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));
                    //DateTime expirationDate = DateTime.UtcNow.AddMinutes(2);


                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, baseUser);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.email,
                name = user.name,
                message = "Usuário Logado com sucesso"
            };
        }

    }
}
