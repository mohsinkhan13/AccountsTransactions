using ConfigurationManager;
using Email.Services;
using System.Configuration;


namespace Email.DomainModel
{
    public class SendEmailMessageConsumer<T> : IMessageConsumer<T> where T : EmailMessage, new()
    {
        public async void Consume(T message)
        {
            //call send grid
            var apiKey = Config.SendGridApiKey;
            ISendable service = new SendGridEmailService(apiKey);

            //just for now
            //var emailMessage = new T()
            //{
            //    To = message.To,
            //    From = message.From,
            //    ContentType = message.ContentType,
            //    Subject = message.Subject,
            //    EmailContent = message.EmailContent
            //};

            //await service.Send(message);
            //raise events send notifications etc

        }

    }
}
