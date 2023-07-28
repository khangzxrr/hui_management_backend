
using hui_management_backend.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasMany(u => u.CreateBy).WithMany().UsingEntity(join => join.ToTable("UserCreateBy"));

    builder.HasMany(u => u.Payments).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Restrict);

    builder.Property(u => u.Identity).IsRequired();
    builder.Property(u => u.Password).IsRequired();
    builder.Property(u => u.Name).IsRequired();
    builder.Property(u => u.Address).IsRequired();
    builder.Property(u => u.BankName).IsRequired();
    builder.Property(u => u.BankNumber).IsRequired();
    builder.Property(u => u.PhoneNumber).IsRequired();

    builder.HasIndex(u => u.PhoneNumber).IsUnique();

    builder.Property(u => u.IdentityCreateDate).IsRequired().HasDefaultValue(DateTimeOffset.Now);


    builder.Property(u => u.Role).HasConversion(u => u.Value, v => RoleName.FromValue(v)).HasDefaultValue(RoleName.User).IsRequired();
  }
}
