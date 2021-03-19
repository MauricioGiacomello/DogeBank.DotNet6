using System;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }

            serviceCollection.AddDbContext<MyContext>(
            options => options.UseSqlServer
                ("Server=.\\SQLEXPRESS20177;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@2805")
            );
        }
    }
}
