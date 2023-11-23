
using Ardalis.GuardClauses;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.PaymentAggregate.Events;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.PaymentAggregate;
public class Payment : EntityBase, IAggregateRoot
{
  public required SubUser Owner { get; set; }
  public int OwnerId { get; set; }
  public required DateTime CreateAt { get; set; }

  public double TotalCost()
  {
    var totalCost = _fundBills.Sum(fb =>
                                    (fb.fromSessionDetail!.type == NormalSessionType.Taken ||
                                    fb.fromSessionDetail!.type == NormalSessionType.EmergencyTaken) ? -fb.fromSessionDetail.payCost : fb.fromSessionDetail.payCost);

    totalCost += _customBills.Sum(cb => cb.type == CustomBillType.OwnerPaid ? -cb.payCost : cb.payCost);

    return totalCost;
  }
   

  public double TotalTransactionCost => _paymentTransactions.Sum(p => p.Amount);

  public required PaymentStatus Status { get; set; } 


  private readonly List<FundBill> _fundBills = new List<FundBill>();
  public IEnumerable<FundBill>  fundBills => _fundBills.AsReadOnly();

  private readonly List<CustomBill> _customBills = new List<CustomBill>();
  public IEnumerable<CustomBill> customBills => _customBills.AsReadOnly();


  private readonly List<PaymentTransaction> _paymentTransactions = new List<PaymentTransaction>();
  public IEnumerable<PaymentTransaction> paymentTransactions => _paymentTransactions.AsReadOnly();

  public void AddCustomBill(CustomBill customBill)
  {
    Guard.Against.Null(customBill);
    _customBills.Add(customBill);
  }

  public void AddBill(FundBill bill)
  {
    Guard.Against.Null(bill);
    _fundBills.Add(bill);
  }

  public void RemoveLatestFundBill(int fundId)
  {
    var latestFundBill = _fundBills.Where(fb => fb.fromFund != null && fb.fromFund!.Id == fundId).LastOrDefault();

    if (latestFundBill != null)
    {
      _fundBills.Remove(latestFundBill);
    }
  }

  public void RemoveAllFundBillByFundId(int fundId)
  {
    _fundBills.RemoveAll(fb => fb.fromFund!.Id == fundId);
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
    _fundBills.RemoveAll(fb => fb.fromSession!.Id == fundBillId);
  }
}
