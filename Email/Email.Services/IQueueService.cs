namespace Email.Services
{
    public interface IQueueService<T> where T : class
    {
        void AddToQueue(T item);
        T RetriveFromQueue();
    }
}
