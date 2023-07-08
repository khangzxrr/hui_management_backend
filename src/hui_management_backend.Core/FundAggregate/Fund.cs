
using Ardalis.GuardClauses;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.FundAggregate;
public class Fund : EntityBase, IAggregateRoot
{
  public string Name { get; private set; } 


  public string OpenDateText { get; private set; }
  public DateTimeOffset OpenDateDuration { get; private set; }

  public double FundPrice { get; private set; }
  public double ServiceCost { get; private set; }

  public User Owner { get; private set; } = null!;


  private readonly List<FundMember> _members = new List<FundMember>();
  public IEnumerable<FundMember> Members => _members.AsReadOnly();

  public Fund(string name, string openDateText, DateTimeOffset openDateDuration, double fundPrice, double serviceCost)
  {
    Name = name;
    OpenDateText = openDateText;
    OpenDateDuration = openDateDuration;
    FundPrice = fundPrice;
    ServiceCost = serviceCost;
  }

  public void SetOwner(User owner)
  {
    Owner = Guard.Against.Null(owner);
  }
}
