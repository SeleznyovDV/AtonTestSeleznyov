using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Guid);

            builder.Property(x => x.Login)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.CreateOn)
                .HasColumnType("datetime2(0)")
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.ModifiedOn)
                .HasColumnType("datetime2(0)");

            builder.Property(x => x.RevokedOn)
                .HasColumnType("datetime2(0)");

            builder.ToTable("Users");
        }
    }
}
