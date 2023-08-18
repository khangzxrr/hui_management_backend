
using hui_management_backend.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasMany(u => u.SubUsers).WithOne(su => su.rootUser).OnDelete(DeleteBehavior.Restrict);
   
    builder.Property(u => u.PhoneNumber).IsRequired();

    builder.HasIndex(u => u.PhoneNumber).IsUnique();

    builder.Property(u => u.Password).IsRequired();

    builder.Property(u => u.Role).HasConversion(u => u.Value, v => RoleName.FromValue(v)).HasDefaultValue(RoleName.User).IsRequired();

    builder.HasMany(u => u.NotificationTokens).WithOne().OnDelete(DeleteBehavior.Cascade);
  }
}
