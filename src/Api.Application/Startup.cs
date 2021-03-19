using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


namespace EstudoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }
        private string dataBaseName = "dbApiTest_" + Guid.NewGuid().ToString().Replace("-", string.Empty);
        private string userName = "sa";
        private string passWord = "mudar@0528";

        public void ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DB_CONNECTION", "Server=.\\SQLEXPRESS20177;Initial Catalog=dbapi_Integration;MultipleActiveResultSets=true;User ID=sa;Password=mudar@2805");
                //Environment.SetEnvironmentVariable("DB_CONNECTION", $"Persist Security Info=True;Server=localhost\\SQLEXPRESS20177;Database=" + dataBaseName + $"; User={userName};Password=mudar@2805");
                Environment.SetEnvironmentVariable("DATABASE", "SQLSERVER");
                Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
                Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
                Environment.SetEnvironmentVariable("Issuer", "ExemploIssue");
                Environment.SetEnvironmentVariable("Seconds", "28800");

            }
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            services.AddControllers();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestToModelProfile());
                cfg.AddProfile(new EntityToRequestProfile());
                cfg.AddProfile(new ModelToEntityProfile());

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguracao = new TokenConfiguracao();
            new ConfigureFromConfigurationOptions<TokenConfiguracao>(
                Configuration.GetSection("TokenConfigurations"))
                            .Configure(tokenConfiguracao);
            services.AddSingleton(tokenConfiguracao);

            services.AddAuthentication(authOptions =>
           {
               authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(bearerOptions =>
{
    var paramsValidation = bearerOptions.TokenValidationParameters;
    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
    paramsValidation.ValidAudience = tokenConfiguracao.Audience;
    paramsValidation.ValidIssuer = tokenConfiguracao.Issuer;

    paramsValidation.ValidateIssuerSigningKey = true;
    paramsValidation.ValidateLifetime = true;
    paramsValidation.ClockSkew = TimeSpan.Zero;
});

            services.AddAuthorization(auth => // Acesso para usar com o token //
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EstudoAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o token JWT",
                    Name = "Autorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference{
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme

                            }
                        }, new List<string>()
                    }
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstudoAPI v1"));
            }

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
            {
                using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
                {
                    using (var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}

