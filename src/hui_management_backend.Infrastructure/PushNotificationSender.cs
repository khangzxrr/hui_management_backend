using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using Microsoft.Extensions.Configuration;

namespace hui_management_backend.Infrastructure;
public class PushNotificationSender : IPushNotificationSender
{

  private readonly FirebaseMessaging _messaging;
  private readonly IRepository<User> _userRepository;

  public PushNotificationSender(IConfiguration configuration, IRepository<User> userRepository)
  {

    var googleCredentialString = configuration.GetRequiredSection("FirebaseAdmin").Value;
    var app = FirebaseApp.Create(new AppOptions() { 
      Credential = GoogleCredential.FromJson(googleCredentialString)
        .CreateScoped("https://www.googleapis.com/auth/firebase.messaging") 
    });

    _messaging = FirebaseMessaging.GetMessaging(app);
    _userRepository = userRepository;
  }

  public async Task sendMultiMessage(IEnumerable<string> tokens, string title, string body)
  {
    MulticastMessage multicastMessage = new MulticastMessage()
    {
      Tokens = tokens.ToList(),
      Notification = new Notification()
      {
        Title = title,
        Body = body
      }
    };

    await _messaging.SendMulticastAsync(multicastMessage);
  }

  public async Task SendPushNotificationAsync(int userId, string subject, string body)
  {
    var userSpec = new NotificationTokensByUserIdSpec(userId);
    var user = await _userRepository.FirstOrDefaultAsync(userSpec);

    if (user == null)
    {
      return;
    }


    var tokens = user.NotificationTokens.Select(t => t.Token).ToList();

    //RecurringJob.AddOrUpdate($"SendPushNotificationAsync-{userId}", (IPushNotificationSender pushNotificationSender) => pushNotificationSender.sendMultiMessage(tokens, subject, body), Cron.Hourly);
  }
}
