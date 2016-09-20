using System.Threading.Tasks;

namespace Email.Services
{
    public interface ISendable
    {
        Task Send(EmailMessage email);
    }
}