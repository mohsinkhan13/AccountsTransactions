using System.Collections.Generic;
using SendGridEmail = SendGrid.Helpers.Mail.Email;


namespace Email.Service
{
    public class EmailMessage
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public List<string> To { get; set; }

        public string EmailContent { get; set; }

        public string ContentType { get; set; }


    }
}