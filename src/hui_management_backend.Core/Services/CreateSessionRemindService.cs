
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class CreateSessionRemindService : ICreateSessionRemindingService
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IPushNotificationSender _pushNotificationSender;

  public CreateSessionRemindService(IRepository<Fund> fundRepository, IPushNotificationSender pushNotificationSender)
  {
    _fundRepository = fundRepository;
    _pushNotificationSender = pushNotificationSender;
  }

  public async Task RemindCreateSession()
  {
    var funds = await _fundRepository.ListAsync(new SystemGetListFundDetailSpec());

    HashSet<int> ownerIds = new HashSet<int>(); 

    DateTimeOffset now = DateTimeOffset.Now;
    foreach(var fund in funds)
    {
      var newSessionCreateDates = fund.newSessionCreateDates();

      var closeDateSessions = newSessionCreateDates.Where(date => date.Date == now.Date);

      if (closeDateSessions.Count() > 0)
      {
        ownerIds.Add(fund.Owner.Id);  
      }
    }

    if (ownerIds.Count() == 0)
    {
      return;
    }

    await _pushNotificationSender.SendPushNotificationForMultipleUsersAsync(ownerIds, "Đến giờ khui hụi!", "Đến giờ khui hụi rồi bạn ơi! Vui lòng vào app để kiểm tra nha");
  }
}
