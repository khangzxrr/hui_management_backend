namespace hui_management_backend.Web.Endpoints.DTOs;

public class SubUserRecord
{

  public int Id { get; set; }
  public string ImageUrl { get; set; }
  public string Identity { get; set; }
  public DateTime IdentityCreateDate { get; set; }
  public string IdentityAddress { get; set; }

  public string? IdentityImageFrontUrl { get; set; }
  public string? IdentityImageBackUrl { get; set; }

  public string NickName { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }

  public string BankName { get; set; }
  public string BankNumber { get; set; }
  public string PhoneNumber { get; set; }
  public string AdditionalInfo { get; set; }

  public SubUserRecord(int id, string imageUrl, string identity, DateTime identityCreateDate, string identityAddress, string? identityImageFrontUrl, string? identityImageBackUrl, string nickName, string name, string address, string bankName, string bankNumber, string phoneNumber, string additionalInfo)
  {
    Id = id;
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
    PhoneNumber = phoneNumber;
    AdditionalInfo = additionalInfo;
  }
}
