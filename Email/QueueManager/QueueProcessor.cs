using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;
using Email.DomainModel;
using System.Net;
using Microsoft.ServiceBus;

namespace Email.QueueManager
{
    public class AzureQueueProcessor : IQueueProcessor
    {

        public AzureQueueProcessor(string queueConnectionString, string queueName)
        {
            Client = CreateQueueIfNotExisting(queueConnectionString, queueName);
        }

        public QueueClient Client { get; set; }

        public void ProcessQueueMessage(BrokeredMessage message)
        {
            var body = message.GetBody<EmailMessage>(new DataContractSerializer(typeof(EmailMessage)));
            
            var consumer = new SendEmailMessageConsumer();
            consumer.Consume(body);
        }

        private QueueClient CreateQueueIfNotExisting(string queueConnectionString , string queueName)
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var namespaceManager = NamespaceManager.CreateFromConnectionString(queueConnectionString);
            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueName);
            }

            return QueueClient.CreateFromConnectionString(queueConnectionString, queueName);
        }
    }
}
