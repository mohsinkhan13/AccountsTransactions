using System.Collections.Generic;

namespace Email.DomainModel
{
    public class EmailMessage
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public List<string> To { get; set; }

        public string EmailBody { get; set; }

        public bool EmailSent { get; set; }
        public bool EmailFailed { get; set; }
    }
}