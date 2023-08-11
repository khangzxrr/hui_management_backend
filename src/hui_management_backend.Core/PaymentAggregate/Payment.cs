
using Ardalis.GuardClauses;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.PaymentAggregate.Events;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.PaymentAggregate;
public class Payment : EntityBase, IAggregateRoot
{
  public required SubUser Owner { get; set;  } 
  public int OwnerId { get; set; }
  public required DateTimeOffset CreateAt { get; set; }

  public double TotalCost => 
    _fundBills.Sum(fb => (fb.fromSessionDetail.type == NormalSessionType.Taken) ? -fb.fromSessionDetail.payCost : fb.fromSessionDetail.payCost);

  public double TotalTransactionCost => _paymentTransactions.Sum(p => p.Amount);

  public required PaymentStatus Status { get; set; } 


  private readonly List<FundBill> _fundBills = new List<FundBill>();
  public IEnumerable<FundBill>  fundBills => _fundBills.AsReadOnly();


  private readonly List<PaymentTransaction> _paymentTransactions = new List<PaymentTransaction>();
  public IEnumerable<PaymentTransaction> paymentTransactions => _paymentTransactions.AsReadOnly();

  public void AddBill(FundBill bill)
  {
    Guard.Against.Null(bill);
    _fundBills.Add(bill);
  }

  public void AddPaymentTransaction(PaymentTransaction transaction)
  {
    Guard.Against.Null(transaction);
    _paymentTransactions.Add(transaction);

    var addTransactionEvent = new AddedTransactionEvent(this);
    RegisterDomainEvent(addTransactionEvent);
  }

  public void SetStatus(PaymentStatus status)
  {
    Status = Guard.Against.Null(status);  
  }

  public void RemoveAllFundBillWithSessionId(int fundBillId)
  {
    _fundBills.RemoveAll(fb => fb.fromSession.Id == fundBillId);
  }
}
