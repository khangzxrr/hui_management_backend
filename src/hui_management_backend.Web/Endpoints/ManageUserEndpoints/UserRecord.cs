namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public record UserRecord(int id, string name, string email, string password, string phonenumber, string bankname, string banknumber, string address, string additionalInfo)
{

}
