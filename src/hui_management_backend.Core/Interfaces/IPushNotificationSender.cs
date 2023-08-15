
namespace hui_management_backend.Core.Interfaces;
public interface IPushNotificationSender
{
  Task SendPushNotificationAsync(string toToken, string subject, string body);
}
