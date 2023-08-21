

using hui_management_backend.Core.FundAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class FundConfiguration : IEntityTypeConfiguration<Fund>
{
  public void Configure(EntityTypeBuilder<Fund> builder)
  {
    builder.HasMany(f => f.Members).WithOne().OnDelete(DeleteBehavior.Restrict);
    builder.HasMany(f => f.Sessions).WithOne().OnDelete(DeleteBehavior.Cascade);

    builder.Property(f => f.FundType)
      .HasConversion(ft => ft.Value, v => FundType.FromValue(v))
      .IsRequired();

    builder.HasQueryFilter(f => !f.IsArchived);
  }
}
