namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public record UserRecord(int id, string imageUrl, string name, string identity, string password, string phonenumber, string bankname, string banknumber, string address, string additionalInfo)
{

}
