
using Ardalis.Specification;

namespace hui_management_backend.Core.MediaAggregate.Specifications;
public class MediaByNameSpec : Specification<Media>, ISingleResultSpecification
{
  public MediaByNameSpec(string name)
  {
    Query
      .Where(m => m.name == name);
  }
}
