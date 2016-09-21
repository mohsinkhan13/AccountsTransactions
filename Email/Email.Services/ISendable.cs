using Email.DomainModel;
using System.Threading.Tasks;
namespace Email.Services
{
    public interface ISendable<T>
    {
        Task Send(T email);
    }
}