using System.Collections.Generic;

namespace Email.Services
{
    public class QueueService<T> : IQueueService<T> where T : class
    {
        private List<T> _queue;

        public List<T> Queue
        {
            get
            {
                return _queue;
            }

            set
            {
                _queue = value;
            }
        }

        public QueueService()
        {
            _queue = new List<T>();
        }

        public void AddToQueue(T item)
        {
            _queue.Add(item);
        }

        public T RetriveFromQueue()
        {
            var item = _queue[0];
            _queue.RemoveAt(0);

            return item;
        }
    }

}
