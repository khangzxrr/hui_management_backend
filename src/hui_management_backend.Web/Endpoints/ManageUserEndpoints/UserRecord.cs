namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public record UserRecord(int id, string imageUrl, string NickName, string name, string identity, DateTimeOffset identityCreateDate, string identityAddress, string password, string phonenumber, string bankname, string banknumber, string address, string additionalInfo, string? identityImageFrontUrl, string? identityImageBackUrl)
{
}
