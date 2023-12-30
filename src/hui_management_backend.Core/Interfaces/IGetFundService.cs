﻿
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetFundService
{
  public Task<Result<IEnumerable<Fund>>> getFunds(int ownerId, int skip, int take);
}
