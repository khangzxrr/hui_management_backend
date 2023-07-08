namespace hui_management_backend.Core.UserAggregate.Records;
public record AuthenticationRecord(int id, string email, string name, string token)
{
}
