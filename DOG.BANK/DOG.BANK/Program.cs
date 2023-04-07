using DOB.ApiDotNet6.Domain.Models;
using DOB.ApiDotNet6.Infra.Data.Services;

var builder = WebApplication.CreateBuilder(args);

//Configurando dataBase
builder.Services.Configure<ProdutoDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));

//Fazendo Injeção de dependencia
builder.Services.AddSingleton<ProdutoServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
