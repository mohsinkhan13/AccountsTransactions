using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGridEmail = SendGrid.Helpers.Mail.Email;


namespace Email.DomainModel
{
    public class SendEmailMessageConsumer : IMessageConsumer<EmailMessage>
    {
        public async void Consume(EmailMessage message)
        {

            //call send grid


            //raise events send notifications etc

        }

        
    }
}
