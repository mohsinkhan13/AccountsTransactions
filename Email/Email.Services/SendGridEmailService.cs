using System.Collections.Generic;
//using Email.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridEmail = SendGrid.Helpers.Mail.Email;
using System.Threading.Tasks;
using Email.DomainModel;

namespace Email.Services
{
    public class SendGridEmailService : ISendable<EmailMessage>
    {
        private string _apiKey;

        public SendGridEmailService(string apiKey)
        {
            _apiKey = apiKey;
            Client = new SendGridAPIClient(_apiKey);
        }

        private SendGridAPIClient Client { get; set; }

        public async Task Send(EmailMessage email)
        {
            var mail = FormSendGridMail(email);

            dynamic response = await Client.client.mail.send.post(requestBody: mail.Get());
        }

        private static Mail FormSendGridMail(EmailMessage message)
        {
            SendGridEmail from = new SendGridEmail(message.From);
            string subject = message.Subject;
            Content content = new Content(message.ContentType, message.EmailContent);
            Mail mail = new Mail();
            mail.From = from;
            mail.Subject = subject;
            mail.AddContent(content);
            var tos = new List<SendGridEmail>();

            foreach (var to in message.To)
            {
                tos.Add(new SendGridEmail(to));
            }

            mail.AddPersonalization(new Personalization
            {
                Tos = tos
            });

            return mail;
        }
    }
}
