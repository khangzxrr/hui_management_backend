using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using hui_management_backend.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace hui_management_backend.Infrastructure;
public class PushNotificationSender : IPushNotificationSender
{

  private readonly FirebaseMessaging _messaging;

  public PushNotificationSender(IConfiguration configuration)
  {

    var googleCredentialString = configuration.GetRequiredSection("FirebaseAdmin").Value;
    var app = FirebaseApp.Create(new AppOptions() { 
      Credential = GoogleCredential.FromJson(googleCredentialString)
        .CreateScoped("https://www.googleapis.com/auth/firebase.messaging") 
    });

    _messaging = FirebaseMessaging.GetMessaging(app);
  }

  public Task SendPushNotificationAsync(string toToken, string subject, string body)
  {
    Message message = new Message()
    {
      Notification = new Notification()
      {
        Title = subject,
        Body = body
      },
      Token = toToken
    };

    return _messaging.SendAsync(message);
  }
}
