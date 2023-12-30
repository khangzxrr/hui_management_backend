
using Ardalis.GuardClauses;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.FundAggregate;
public class Fund : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public bool IsArchived { get; private set; }

  public FundType FundType { get; private set; }

  public int NewSessionDurationCount { get; private set; }

  public int TakenSessionDeliveryCount { get; private set; }

  public int NewSessionCreateDayOfMonth { get; private set; }

  public DateTime NewSessionCreateHourOfDay { get; private set; }

  public DateTime TakenSessionDeliveryHourOfDay { get; private set; }

  public DateTime OpenDate { get; private set; }

  public double FundPrice { get; private set; }
  public double ServiceCost { get; private set; }

  public User Owner { get; private set; } = null!;



  private readonly List<FundMember> _members = new List<FundMember>();
  public IEnumerable<FundMember> Members => _members.AsReadOnly();


  private readonly List<FundSession> _sessions = new List<FundSession>();
  public IEnumerable<FundSession> Sessions => _sessions.AsReadOnly();

  public DateTime EndDate =>  _members.Count < 2 ? OpenDate : newSessionCreateDates().Last();

  private DateTime ReplaceDayInDateTime(DateTime dateTime, int day)
  {
    return new DateTime(dateTime.Year, dateTime.Month, day, dateTime.Hour, dateTime.Minute, dateTime.Second);
  }

  public void setArchived(bool isArchived)
  {
    IsArchived = isArchived;
  }

  public bool isEnd() => _sessions.Count() == _members.Count();

  public IEnumerable<DateTime> newSessionCreateDates()
  {
    var newSessionCreateDates = new List<DateTime>();

    DateTime previousDate = OpenDate;

    if (this.FundType == FundType.MonthFund)
    {
      //hot fix: i = 1, because if we repeat by session.count
      //when session count == member count
      //=> newSessionCreateDates.last() => throw exception
      for (int i = 1; i < _members.Count; i++)
      {
        var newCreateDate = previousDate.AddMonths(NewSessionCreateDayOfMonth);
        newSessionCreateDates.Add(ReplaceDayInDateTime(newCreateDate, NewSessionDurationCount));

        previousDate = newCreateDate;
      }
    }
    else
    {
      newSessionCreateDates.Add(OpenDate);

      for (int i = 1; i < _members.Count; i++)
      {
        DateTime newCreatedDate = previousDate.AddDays(NewSessionDurationCount);

        //in single day fund, we dont have to calculate shift days
        if ((newCreatedDate.Month != previousDate.Month) && NewSessionDurationCount > 1)
        {

          int shiftedDayCount = DateTime.DaysInMonth(previousDate.Year, previousDate.Month) - 30;

          newCreatedDate = previousDate.AddDays(NewSessionDurationCount + shiftedDayCount);
        }

        previousDate = newCreatedDate;
        newSessionCreateDates.Add(newCreatedDate);
      }
    }
   
    //empty create dates
    
    return newSessionCreateDates;
  }

  public Fund(
    string name,
    int newSessionDurationCount,
    int takenSessionDeliveryCount,
    int newSessionCreateDayOfMonth,
    DateTime newSessionCreateHourOfDay,
    DateTime takenSessionDeliveryHourOfDay,
    DateTime openDate,
    double fundPrice,
    double serviceCost,
    FundType fundType)
  {
    Name = name;

    NewSessionDurationCount = newSessionDurationCount;
    TakenSessionDeliveryCount = takenSessionDeliveryCount;

    NewSessionCreateDayOfMonth = newSessionCreateDayOfMonth;

    NewSessionCreateHourOfDay = newSessionCreateHourOfDay;
    TakenSessionDeliveryHourOfDay = takenSessionDeliveryHourOfDay;

    OpenDate = openDate;
    FundPrice = fundPrice;
    ServiceCost = serviceCost;

    IsArchived = false;
    FundType = fundType;
  }

  public void RemoveAllMember()
  {
    _members.RemoveAll(_members => true);
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

  public void SetNewSessionDurationDayCount(int newSessionDurationDayCount)
  {
    NewSessionDurationCount = Guard.Against.Negative(newSessionDurationDayCount);
  }

  public void SetTakenSessionDeliveryDayCount(int takenSessionDeliveryDayCount)
  {
    TakenSessionDeliveryCount = Guard.Against.Negative(takenSessionDeliveryDayCount);
  }

  public void SetOpenDate(DateTime openDate)
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

  public void RemoveSession(FundSession session)
  {
    Guard.Against.Null(session);

    _sessions.Remove(session);
  }

  public void SetFundType(FundType fundType)
  {
    FundType = Guard.Against.Null(fundType);
  }

  public void SetNewSessionCreateDayOfMonth(int newSessionCreateDayOfMonth)
  {
    NewSessionCreateDayOfMonth = Guard.Against.Negative(newSessionCreateDayOfMonth);
  }

  public void SetNewSessionCreateHourOfDay(DateTime newSessionCreateHourOfDay)
  {
    NewSessionCreateHourOfDay = Guard.Against.Null(newSessionCreateHourOfDay);
  }

  public void SetTakenSessionDeliveryHourOfDay(DateTime takenSessionDeliveryHourOfDay)
  {
    TakenSessionDeliveryHourOfDay = Guard.Against.Null(takenSessionDeliveryHourOfDay);
  }

}
