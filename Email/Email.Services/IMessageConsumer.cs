namespace Email.Services
{
    public interface IMessageConsumer<T>
    {
        void Consume(T message);
    }
}
