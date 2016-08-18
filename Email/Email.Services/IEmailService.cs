using Email.Service;
using SendGrid;
using System;
using System.Threading.Tasks;

namespace Email.Services
{
    public interface IEmailService
    {
        Task Send(EmailMessage email);
    }
}
