
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundBillConfiguration : IEntityTypeConfiguration<FundBill>
{
  public void Configure(EntityTypeBuilder<FundBill> builder)
  {
    builder.HasOne(b => b.fromSession).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(b => b.fromSessionDetail).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(b => b.fromFund).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);

    builder.HasQueryFilter(fb => !(fb.fromFund!.IsArchived));
  }

}
