using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>

    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.nameFather).HasMaxLength(60);
            builder.Property(u => u.nameMother).HasMaxLength(60);
            builder.HasIndex(u => u.email);

        }
    }
}
