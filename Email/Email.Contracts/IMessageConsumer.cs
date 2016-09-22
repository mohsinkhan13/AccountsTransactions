using Email.DomainModel;

namespace Email.Contracts
{ 
    public interface IMessageConsumer<T> where T : Message
    {
        void Consume(T message);
    }
}
