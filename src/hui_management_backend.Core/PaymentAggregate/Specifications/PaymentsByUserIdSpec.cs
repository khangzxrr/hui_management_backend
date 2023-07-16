﻿
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentsByUserIdSpec: Specification<Payment>
{
  public PaymentsByUserIdSpec(int userId) {
    Query
      .Include(p => p.Owner)
      .Include(p => p.paymentTransactions)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromFund)
      .Where(p => p.OwnerId == userId);
  }
}
