namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class DeleteRequest
{
  public const string Route = "/users/{id:int}";

  public static string BuildRoute(int id) => Route.Replace("{id:int}", id.ToString());

  public int id { get; set; }
}
