using System;

namespace Email.Services
{
    public interface IEmailService
    {
        EmailModel GetEmail(Guid emailId);
        void Send(EmailModel email);
    }
}
