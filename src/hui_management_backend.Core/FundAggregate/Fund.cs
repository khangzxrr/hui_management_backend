
using Ardalis.GuardClauses;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.FundAggregate;
public class Fund : EntityBase, IAggregateRoot
{
  public string Name { get; private set; } 

  public bool IsArchived { get; private set; }

  public string OpenDateText { get; private set; }
  public DateTimeOffset OpenDate { get; private set; }

  public double FundPrice { get; private set; }
  public double ServiceCost { get; private set; }

  public User Owner { get; private set; } = null!;


  private readonly List<FundMember> _members = new List<FundMember>();
  public IEnumerable<FundMember> Members => _members.AsReadOnly();


  private readonly List<FundSession> _sessions = new List<FundSession>();
  public IEnumerable<FundSession> Sessions => _sessions.AsReadOnly();

  public Fund(string name, string openDateText, DateTimeOffset openDate, double fundPrice, double serviceCost)
  {
    Name = name;
    OpenDateText = openDateText;
    OpenDate = openDate;
    FundPrice = fundPrice;
    ServiceCost = serviceCost;

    IsArchived = false;
  }

  public void AddMember(FundMember member)
  {
    Guard.Against.Null(member);

    _members.Add(member);
  }

  public void RemoveMember(FundMember member)
  {
    Guard.Against.Null(member);

    _members.Remove(member);
  }

  public void SetArchived(bool archived)
  {
    IsArchived = Guard.Against.Null(archived);
  }
  public void SetOwner(User owner)
  {
    Owner = Guard.Against.Null(owner);
  }

  public void SetName(string name)
  {
    Name = Guard.Against.NullOrEmpty(name);
  }

  public void SetOpenDateText(string openDateText)
  {
    OpenDateText = Guard.Against.NullOrEmpty(openDateText);
  }

  public void SetOpenDate(DateTimeOffset openDate)
  {
    OpenDate = Guard.Against.Null(openDate);
  }

  public void SetFundPrice(double fundPrice)
  {
    FundPrice = Guard.Against.NegativeOrZero(fundPrice);
  }

  public void SetServiceCost(double serviceCost)
  {
    ServiceCost = Guard.Against.NegativeOrZero(serviceCost);
  }

  public void AddSession(FundSession session)
  {
    Guard.Against.Null(session);
    _sessions.Add(session);
  }
}
