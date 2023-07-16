﻿using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetUserPaymentsRequest
{
  public const string Route = "/owner/users/{userId}/payments";

  [FromRoute]
  public int userId { get; set; }
}
