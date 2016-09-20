using System;
using System.Collections.Generic;
using SendGridEmail = SendGrid.Helpers.Mail.Email;


namespace Email.Services
{
    [Serializable]
    public class EmailMessage
    {
        public EmailMessage()
        {
            ContentType = EmailContentType.TextPlain;
        }
        public string From { get; set; }
        public string Subject { get; set; }
        public List<string> To { get; set; }

        public string EmailContent { get; set; }

        public string ContentType { get; set; }


    }
}