using Email.DomainModel;
using System;

namespace Email.QueueManager
{
    public interface IQueue : IDisposable
    {
        void Enqueue(EmailMessage message);
    }
}
