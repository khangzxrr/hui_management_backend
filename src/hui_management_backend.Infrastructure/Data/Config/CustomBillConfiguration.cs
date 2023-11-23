

using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class CustomBillConfiguration : IEntityTypeConfiguration<CustomBill>
{
  public void Configure(EntityTypeBuilder<CustomBill> builder)
  {
    builder.Property(cb => cb.type)
      .IsRequired()
      .HasConversion(t => t.Value, v => CustomBillType.FromValue(v));
  }
}
