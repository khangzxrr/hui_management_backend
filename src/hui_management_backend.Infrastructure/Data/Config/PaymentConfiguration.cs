﻿
using hui_management_backend.Core.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hui_management_backend.Infrastructure.Data.Config;
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
  public void Configure(EntityTypeBuilder<Payment> builder)
  {

    builder.HasOne(p => p.Owner).WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey(p => p.OwnerId);

    builder.HasMany(p => p.PaymentTransactions).WithOne().OnDelete(DeleteBehavior.Cascade);

    builder.Property(p => p.Status)
      .HasConversion(
        p => p.Value,
        v => PaymentStatus.FromValue(v))
      .HasDefaultValue(PaymentStatus.Processing)
      .IsRequired();

    builder.Property(p => p.Type)
      .HasConversion(pt => pt.Value,v => PaymentType.FromValue(v))
      .HasDefaultValue(PaymentType.TransferToOwner)
      .IsRequired();
  }
}
