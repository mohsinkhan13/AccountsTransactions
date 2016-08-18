using Email.Service;
using Email.Services;
using System.Configuration;


namespace Email.DomainModel
{
    public class SendEmailMessageConsumer : IMessageConsumer<EmailMessage>
    {
        public async void Consume(EmailMessage message)
        {
            //call send grid
            var apiKey = ConfigurationManager.AppSettings["apikey"] ?? string.Empty;
            IEmailService service = new SendGridEmailService(apiKey);
            await service.Send(message);
            //raise events send notifications etc

        }

    }
}
