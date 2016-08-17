using System;
using System.Collections.Generic;

namespace Email.Services
{
    public class EmailService : IEmailService
    {
        private IQueueService<EmailModel> _queueService;

        //TODO remove after Ioc implementation
        public EmailService()
        {
            _queueService = new QueueService<EmailModel>();
        }

        public EmailService(IQueueService<EmailModel> queueService)
        {
            _queueService = queueService;
        }

        public EmailModel GetEmail(Guid emailId)
        {
            return new EmailModel
            {
                To = new List<string> { "mohsin.khan@wolterskluwer.com" },
                From = "mohsin.khan@wolterskluwer.com",
                Subject = "Test email",
                EmailBody = "This is a test email sent to test this service"
            };
        }

        public void Send(EmailModel email)
        {
            throw new NotImplementedException();
        }
    }
}
