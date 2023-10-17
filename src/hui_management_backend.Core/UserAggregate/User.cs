using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.SharedKernel;
using Ardalis.GuardClauses;

namespace hui_management_backend.Core.UserAggregate;
public class User : EntityBase, IAggregateRoot
{
  
  public string PhoneNumber { get; private set; }

  public string Password { get; private set; }

  public RoleName Role { get; private set; }

  private readonly List<NotificationToken> _notificationTokens = new();
  public IEnumerable<NotificationToken> NotificationTokens => _notificationTokens.AsReadOnly();

  private readonly List<SubUser> _subUsers = new();
  public IEnumerable<SubUser> SubUsers => _subUsers.AsReadOnly();

  public SubUser? SubUserOfOwner(User owner)
  {
    return _subUsers.Where(s => s.createBy == owner).FirstOrDefault();
  }

  public SubUser? SubUserOfOwnerById(int ownerId)
  {
    return _subUsers.Where(s => s.createBy.Id == ownerId).FirstOrDefault();
  }

  public bool DeleteSubUserByOwnerId(int ownerId)
  {
    var subUser = SubUserOfOwnerById(ownerId);

    if (subUser == null) return false;
    _subUsers.Remove(subUser);
    return true;
  }

  public SubUser AddSubUser(string imageUrl, string identity, DateTime identityCreateDate, string identityAddress, string? identityImageFrontUrl, string? identityImageBackUrl, string nickName, string name, string address, string bankName, string bankNumber, string additionalInfo, User createBy)
  {
    
    var subUser = new SubUser(imageUrl, identity, identityCreateDate, identityAddress, identityImageFrontUrl, identityImageBackUrl, nickName, name, address, bankName, bankNumber, additionalInfo);

    subUser.SetRootUser(this);
    subUser.SetCreateBy(createBy);

    _subUsers.Add(subUser);

    return subUser;
  }

  public User(string phoneNumber, string password, RoleName role)
  {

    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    Password = Guard.Against.NullOrEmpty(password);
    Role = Guard.Against.Null(role);
  } 

  public void UpdatePhoneNumber(string phoneNumber) {
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
  }

  public void AddNotificationToken(string token)
  {
    Guard.Against.NullOrEmpty(token);
    _notificationTokens.Add(new NotificationToken(token));
  }
}
