using Microsoft.ServiceBus.Messaging;

namespace Email.QueueManager
{
    public interface IQueueProcessor
    {
        void ProcessQueueMessage(BrokeredMessage message);
        QueueClient Client { get; set; }
    }
        
}