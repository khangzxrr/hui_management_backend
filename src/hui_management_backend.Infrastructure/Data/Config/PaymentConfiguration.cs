
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
  public void Configure(EntityTypeBuilder<Payment> builder)
  {
    builder.HasOne(b => b.Owner).WithMany().HasForeignKey(b => b.OwnerId).OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(p => p.paymentTransactions).WithOne().OnDelete(DeleteBehavior.Cascade);
    builder.HasMany(p => p.fundBills).WithOne().OnDelete(DeleteBehavior.Cascade);

    builder.Property(p => p.Status)
      .HasConversion(
        p => p.Value,
        v => PaymentStatus.FromValue(v))
      .HasDefaultValue(PaymentStatus.Processing)
      .IsRequired();

    builder.HasIndex(p => p.CreateAt)
      .IsUnique();
   
  }
}
