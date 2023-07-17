
using hui_management_backend.Core.FundAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class NormalSessionDetailConfiguration : IEntityTypeConfiguration<NormalSessionDetail>
{
  public void Configure(EntityTypeBuilder<NormalSessionDetail> builder)
  {
    builder.Property(nsd => nsd.type)
      .HasConversion(nsd => nsd.Value, v => NormalSessionType.FromValue(v))
      .IsRequired();
  }
}
