using Email.DomainModel;
using System;

namespace Queue.Contracts
{
    public interface IQueue : IDisposable
    {
        void Enqueue(EmailMessage message);
    }
}
