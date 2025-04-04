using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Types;
using System;

namespace AppWhatsAppChatGPT.Services
{
    public static class WhatsAppService
    {
        private static readonly string accountSid = "TWILIO_ACCOUNT_SID";
        private static readonly string authToken = "TWILIO_AUTH_TOKEN";
        private static readonly string fromPhoneNumber = "TWILIO_FROM_PHONE_NUMBER";

        public static void SendWhatsAppMessage(string toPhoneNumber, string message)
        {
            try
            {
                TwilioClient.Init(accountSid, authToken);

                var messageResource = MessageResource.Create(
                    body: message,
                    from: new PhoneNumber(fromPhoneNumber),
                    to: new PhoneNumber($"whatsapp:{toPhoneNumber}")
                );

                Console.WriteLine($"Message sent to {toPhoneNumber}: {messageResource.Sid}");
            }
            catch (ApiException e)
            {
                Console.WriteLine($"Error sending WhatsApp message: {e.Message}");
            }
        }
    }
}
