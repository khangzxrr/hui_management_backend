
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundBillConfiguration : IEntityTypeConfiguration<FundBill>
{
  public void Configure(EntityTypeBuilder<FundBill> builder)
  {
    builder.HasOne(b => b.fromFund).WithMany().OnDelete(DeleteBehavior.Restrict);


    builder.Property(p => p.Type)
      .HasConversion(pt => pt.Value, v => PaymentType.FromValue(v))
      .IsRequired();

    builder.Property(p => p.Status)
      .HasConversion(pt => pt.Value, v => PaymentStatus.FromValue(v))
      .HasDefaultValue(PaymentStatus.Processing)
      .IsRequired();
  }
}
