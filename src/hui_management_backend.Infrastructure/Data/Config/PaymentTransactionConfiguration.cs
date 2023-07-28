
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
{
  public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
  {
    builder.Property(pt => pt.Method)
      .HasConversion(pm => pm.Value, v => TransactionMethod.FromValue(v));

    builder.HasMany(builder => builder.transactionImages).WithOne().OnDelete(DeleteBehavior.Cascade);
  }
}
