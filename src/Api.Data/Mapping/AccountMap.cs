using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.ToTable("AccountsUser");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.accountNumber).IsRequired().HasMaxLength(10);
            builder.Property(u => u.balanceCredit).IsRequired().HasMaxLength(30);
            builder.Property(u => u.accountType).IsRequired().HasMaxLength(30);

        }
    }
}
