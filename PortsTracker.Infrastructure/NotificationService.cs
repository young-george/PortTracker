using PortsTracker.Application;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PortsTracker.Infrastructure;

public class NotificationService : INotificationService
{
    public async Task Send(string phoneNumber, string message)
    {
        TwilioClient.Init("ACbf2eb0585dbd77ef726787f3b2398be7", "7249b3429f667620fd9aa39b9fab36f2");

        var twilioMessage = await MessageResource.CreateAsync(
            body: message,
            from: new Twilio.Types.PhoneNumber("(615) 398-6043"),
            to: new Twilio.Types.PhoneNumber(phoneNumber));
    }
}