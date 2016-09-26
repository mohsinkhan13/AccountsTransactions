using Email.DomainModel;
using System;

namespace Queue.Contracts
{
    public interface IQueue<T> : IDisposable
    {
        void Enqueue(T message);
    }
}
