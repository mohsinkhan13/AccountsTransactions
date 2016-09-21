using ConfigurationManager;
using Email.DomainModel;

namespace Email.Services
{
    public class SendEmailMessageConsumer<T> : IMessageConsumer<T> where T : EmailMessage, new()
    {
        //private readonly ISendable<T> _service;

        //public SendEmailMessageConsumer(ISendable<T> service)
        //{
        //    _service = service;
        //}

        public async void Consume(T message)
        {
            var apiKey = Config.SendGridApiKey;
            ISendable<T> service = new SendGridEmailService<T>(apiKey);
            await service.Send(message);
        }

    }

    
}
