//Conceção com o banco de dados e disponibilizar os DbSet//

using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<AccountEntity> AccountsUser { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        // Construtor padrão para o Db //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<AccountEntity>(new AccountMap().Configure);
            //modelBuilder.Entity<BaseEntity>();

        }
    }
}
