
using Ardalis.GuardClauses;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.UserAggregate;
public class SubUser : EntityBase, IAggregateRoot
{
  public int rootUserId { get; set; }
  public User rootUser { get; set; } = null!;

  public int createById { get; set; }
  public User createBy { get; set; } = null!;

  public string ImageUrl { get; private set; }
  public string Identity { get; private set; }
  public DateTimeOffset IdentityCreateDate { get; private set; }
  public string IdentityAddress { get; private set; }

  public string? IdentityImageFrontUrl { get; private set; }
  public string? IdentityImageBackUrl { get; private set; }

  public string NickName { get; private set; }

  public string Name { get; private set; }
  public string Address { get; private set; }
  public string BankName { get; private set; }
  public string BankNumber { get; private set; }

  public string AdditionalInfo { get; private set; }

  public string PhoneNumber => rootUser.PhoneNumber;


  private readonly List<Payment> _payments = new();
  public IEnumerable<Payment> Payments => _payments.AsReadOnly();


  public double totalAliveAmount => 
    _payments
    .SelectMany(p => p.fundBills)
    .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Alive)
    .Sum(fb => fb.fromSessionDetail!.payCost);

  public double totalDeadAmount =>
    _payments
    .SelectMany(p => p.fundBills)
    .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Dead)
    .Sum(fb => fb.fromSessionDetail!.payCost);

  public double totalTakenAmount =>
    _payments
    .SelectMany(p => p.fundBills)
    .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Taken)
    .Sum(fb => fb.fromSessionDetail!.payCost);
  public double totalProcessingAmount => _payments.Where(p => p.Status == PaymentStatus.Processing).Sum(p => p.TotalCost);

  public double totalDebtAmount => _payments.Where(p => p.Status == PaymentStatus.Debting).Sum(p => p.TotalCost);

  public double fundRatio => totalAliveAmount - (totalDeadAmount + totalTakenAmount);



  public SubUser(
    string imageUrl, 
    string identity, 
    DateTimeOffset identityCreateDate, 
    string identityAddress, 
    string? identityImageFrontUrl, 
    string? identityImageBackUrl, 
    string nickName, 
    string name, 
    string address, 
    string bankName, 
    string bankNumber, 
    string additionalInfo)
  {
    ImageUrl = imageUrl;
    Identity = identity;
    IdentityCreateDate = identityCreateDate;
    IdentityAddress = identityAddress;
    IdentityImageFrontUrl = identityImageFrontUrl;
    IdentityImageBackUrl = identityImageBackUrl;
    NickName = nickName;
    Name = name;
    Address = address;
    BankName = bankName;
    BankNumber = bankNumber;
    AdditionalInfo = additionalInfo;    
  }

  public void SetRootUser(User user)
  {
    rootUser = Guard.Against.Null(user);
  }

  public void SetCreateBy(User user)
  {
    createBy = Guard.Against.Null(user);
  }
  //update identity create date
  public void UpdateIdentityCreateDate(DateTimeOffset identityCreateDate)
  {
    IdentityCreateDate = Guard.Against.Null(identityCreateDate);
  }

  //update identity image front url
  public void UpdateIdentityImageFrontUrl(string? identityImageFrontUrl)
  {
    IdentityImageFrontUrl = identityImageFrontUrl;
  }

  //update nick name
  public void UpdateNickName(string nickName)
  {
    NickName = Guard.Against.NullOrEmpty(nickName);
  }

  //update identity image back url
  public void UpdateIdentityImageBackUrl(string? identityImageBackUrl)
  {
    IdentityImageBackUrl = identityImageBackUrl;
  }

  //update identity address
  public void UpdateIdentityAddress(string identityAddress)
  {
    IdentityAddress = Guard.Against.NullOrEmpty(identityAddress);
  }



  public void UpdateIdentity(string email)
  {
    Identity = Guard.Against.NullOrEmpty(email);
  }

  public void UpdateImageUrl(string imageUrl)
  {
    ImageUrl = Guard.Against.NullOrEmpty(imageUrl);
  }

  public void UpdateName(string name)
  {
    Name = Guard.Against.NullOrEmpty(name);
  }

  public void UpdateAddress(string address)
  {
    Address = Guard.Against.NullOrEmpty(address);
  }

  public void UpdateBankNumber(string bankNumber)
  {
    BankNumber = Guard.Against.NullOrEmpty(bankNumber);
  }

  public void UpdateBankName(string bankName)
  {
    BankName = Guard.Against.NullOrEmpty(bankName);
  }

  public void UpdateAdditionalInfo(string additionalInfo)
  {
    AdditionalInfo = Guard.Against.Null(additionalInfo);
  }
}
