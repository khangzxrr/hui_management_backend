
namespace hui_management_backend.Core.Interfaces;
public interface IPushNotificationSender
{
  Task SendPushNotificationAsync(int userId, string subject, string body);
  Task sendMultiMessage(IEnumerable<string> tokens, string title, string body);
}
