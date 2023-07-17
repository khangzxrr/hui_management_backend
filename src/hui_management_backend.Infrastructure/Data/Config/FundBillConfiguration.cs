
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundBillConfiguration : IEntityTypeConfiguration<FundBill>
{
  public void Configure(EntityTypeBuilder<FundBill> builder)
  {
    builder.HasOne(b => b.fromFund).WithMany().OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(b => b.fromSessionDetail).WithMany().OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(b => b.fromSession).WithMany().OnDelete(DeleteBehavior.Cascade);
  }
}
