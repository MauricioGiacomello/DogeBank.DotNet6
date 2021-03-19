using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=.\\SQLEXPRESS20177;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@2805";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
