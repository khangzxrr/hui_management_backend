using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.SharedKernel;
using Ardalis.GuardClauses;
using hui_management_backend.Core.PaymentAggregate;

namespace hui_management_backend.Core.UserAggregate;
public class User : EntityBase, IAggregateRoot
{
  public string ImageUrl { get; private set; }
  public string Identity { get; private set; }
  public DateTimeOffset IdentityCreateDate { get; private set; }
  public string IdentityAddress { get; private set; }

  public string IdentityImageFrontUrl { get; private set; }
  public string IdentityImageBackUrl { get; private set; }

  public string Name { get; private set; }
  public string Address { get; private set; }
  public string BankName { get; private set; }
  public string BankNumber { get; private set; }
  public string PhoneNumber { get; private set; }
  public string AdditionalInfo { get; private set; }

  public string Password { get; private set; }

  public RoleName Role { get; private set; }

  private readonly List<User> _createBy = new();
  public IEnumerable<User> CreateBy => _createBy.AsReadOnly();


  private readonly List<Payment> _payments = new();
  public IEnumerable<Payment> Payments => _payments.AsReadOnly();

  public User(string imageUrl, string identity, DateTimeOffset identityCreateDate, string identityAddress, string password, string name, string address, string bankName, string bankNumber, string phoneNumber, string additionalInfo, RoleName role, string identityImageFrontUrl = "", string identityImageBackUrl = "")
  {
    ImageUrl = Guard.Against.NullOrEmpty(imageUrl);
    
    Password = Guard.Against.NullOrEmpty(password);
    Name = Guard.Against.NullOrEmpty(name);
    Address = Guard.Against.NullOrEmpty(address);
    BankName = Guard.Against.NullOrEmpty(bankName);
    BankNumber = Guard.Against.NullOrEmpty(bankNumber);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    AdditionalInfo = Guard.Against.Null(additionalInfo);

    Identity = Guard.Against.NullOrEmpty(identity);
    IdentityCreateDate = Guard.Against.Null(identityCreateDate);
    IdentityAddress = Guard.Against.Null(identityAddress);

    IdentityImageFrontUrl = identityImageFrontUrl;
    IdentityImageBackUrl = identityImageBackUrl;

    Role = Guard.Against.Null(role);
  } 

  //update identity create date
  public void UpdateIdentityCreateDate(DateTimeOffset identityCreateDate)
  {
    IdentityCreateDate = Guard.Against.Null(identityCreateDate);
  }

  //update identity image front url
  public void UpdateIdentityImageFrontUrl(string identityImageFrontUrl)
  {
    IdentityImageFrontUrl = Guard.Against.Null(identityImageFrontUrl);
  }

   //update identity image back url
   public void UpdateIdentityImageBackUrl(string identityImageBackUrl)
  {
      IdentityImageBackUrl = Guard.Against.Null(identityImageBackUrl);
    }

  //update identity address
  public void UpdateIdentityAddress(string identityAddress)
  {
    IdentityAddress = Guard.Against.NullOrEmpty(identityAddress);
  }
  public bool IsCreateByCreatorId(int creatorId)
  {
    return _createBy.Any(u => u.Id == creatorId);
  }

  public void AddCreateBy(User user)
  {
    if (user == this) return;

    _createBy.Add(Guard.Against.Null(user));
  }

  //remove creator from _createBy
  public void RemoveCreateBy(User user)
  {
    if (user == this) return;

    _createBy.Remove(Guard.Against.Null(user));
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

  public void UpdatePhoneNumber(string phoneNumber) {
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
  }

  public void UpdateAdditionalInfo(string additionalInfo)
  {
    AdditionalInfo = Guard.Against.Null(additionalInfo);
  }


}
