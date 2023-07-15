using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.SharedKernel;
using Ardalis.GuardClauses;

namespace hui_management_backend.Core.UserAggregate;
public class User : EntityBase, IAggregateRoot
{
  public string Email { get; private set; }
  public string Name { get; private set; }
  public string Address { get; private set; }
  public string BankName { get; private set; }
  public string BankNumber { get; private set; }
  public string PhoneNumber { get; private set; }
  public string AdditionalInfo { get; private set; }

  public string Password { get; private set; }

  public RoleName Role { get; private set; }

  public User(string email, string password, string name, string address, string bankName, string bankNumber, string phoneNumber, string additionalInfo, RoleName role)
  {
    Email = Guard.Against.NullOrEmpty(email);
    Password = Guard.Against.NullOrEmpty(password);
    Name = Guard.Against.NullOrEmpty(name);
    Address = Guard.Against.NullOrEmpty(address);
    BankName = Guard.Against.NullOrEmpty(bankName);
    BankNumber = Guard.Against.NullOrEmpty(bankNumber);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    AdditionalInfo = Guard.Against.Null(additionalInfo);

    Role = Guard.Against.Null(role);
  } 

  public void UpdateEmail(string email)
  {
    Email = Guard.Against.NullOrEmpty(email);
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
