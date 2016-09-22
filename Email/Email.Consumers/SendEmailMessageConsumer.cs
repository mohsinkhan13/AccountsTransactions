using Email.Contracts;
using Email.DomainModel;

namespace Email.Consumers
{
    public class SendEmailMessageConsumer : IMessageConsumer<EmailMessage>
    {
        private readonly ISendable<EmailMessage> _service;

        //TODO - IoC
        public SendEmailMessageConsumer(ISendable<EmailMessage> service)
        {
            _service = service;
        }

        public async void Consume(EmailMessage message)
        {
            await _service.Send(message);
        }

    }

    
}
