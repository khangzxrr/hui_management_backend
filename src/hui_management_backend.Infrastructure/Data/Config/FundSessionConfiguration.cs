using hui_management_backend.Core.FundAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundSessionConfiguration : IEntityTypeConfiguration<FundSession>
{
  public void Configure(EntityTypeBuilder<FundSession> builder)
  {

    builder.HasMany(fs => fs.normalSessionDetails).WithOne().OnDelete(DeleteBehavior.Cascade);

  }
}
