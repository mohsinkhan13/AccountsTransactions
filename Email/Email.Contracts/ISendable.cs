using Email.DomainModel;
using System.Threading.Tasks;

namespace Email.Contracts
{
    public interface ISendable<T>
    {
        Task Send(T email);
    }
}