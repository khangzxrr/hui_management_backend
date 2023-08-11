
using hui_management_backend.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class SubUserConfiguration : IEntityTypeConfiguration<SubUser>
{
  public void Configure(EntityTypeBuilder<SubUser> builder)
  {

    builder.Property(u => u.Identity).IsRequired();

    builder.Property(u => u.Name).IsRequired();
    builder.Property(u => u.Address).IsRequired();
    builder.Property(u => u.BankName).IsRequired();
    builder.Property(u => u.BankNumber).IsRequired();

    builder.Property(u => u.NickName).IsRequired().HasDefaultValue("Chưa có nick name");

    builder.Property(u => u.IdentityCreateDate).IsRequired().HasDefaultValue(DateTimeOffset.Now);

    builder.HasOne(su => su.createBy).WithMany().HasForeignKey(su => su.createById)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(su => su.rootUser).WithMany(u => u.SubUsers).HasForeignKey(su => su.rootUserId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasMany(su => su.Payments).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Restrict);

    builder.HasIndex(u => new { u.rootUserId, u.createById }).IsUnique();
  }
}
