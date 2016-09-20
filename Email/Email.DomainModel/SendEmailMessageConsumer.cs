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
            ISendable service = new SendGridEmailService(apiKey);

            //just for now
            var emailMessage = new Email.Services.EmailMessage
            {
                To = message.To,
                From = message.From,
                ContentType = message.ContentType,
                Subject = message.Subject,
                EmailContent = message.EmailContent
            };

            await service.Send(emailMessage);
            //raise events send notifications etc

        }

    }
}
