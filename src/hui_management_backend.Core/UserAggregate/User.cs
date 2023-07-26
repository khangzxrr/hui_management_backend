using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.SharedKernel;
using Ardalis.GuardClauses;
using hui_management_backend.Core.PaymentAggregate;

namespace hui_management_backend.Core.UserAggregate;
public class User : EntityBase, IAggregateRoot
{
  public string ImageUrl { get; private set; }
  public string Identity { get; private set; }
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

  public User(string imageUrl, string identity, string password, string name, string address, string bankName, string bankNumber, string phoneNumber, string additionalInfo, RoleName role)
  {
    ImageUrl = Guard.Against.NullOrEmpty(imageUrl);
    Identity = Guard.Against.NullOrEmpty(identity);
    Password = Guard.Against.NullOrEmpty(password);
    Name = Guard.Against.NullOrEmpty(name);
    Address = Guard.Against.NullOrEmpty(address);
    BankName = Guard.Against.NullOrEmpty(bankName);
    BankNumber = Guard.Against.NullOrEmpty(bankNumber);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    AdditionalInfo = Guard.Against.Null(additionalInfo);

    Role = Guard.Against.Null(role);
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
