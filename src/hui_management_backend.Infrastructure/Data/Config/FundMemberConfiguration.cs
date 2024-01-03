
using hui_management_backend.Core.FundAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundMemberConfiguration : IEntityTypeConfiguration<FundMember>
{
  public void Configure(EntityTypeBuilder<FundMember> builder)
  {
    builder.HasOne(f => f.subUser).WithMany().OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(f => f.finalSettlementForDeadSessionBill).WithOne().HasForeignKey<FundMember>(fm => fm.finalSettlementForDeadSessionBillId).OnDelete(DeleteBehavior.Cascade);

  }
}
