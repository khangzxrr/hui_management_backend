using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundMemberRecord(int id, string nickName, UserRecord user)
{
}
