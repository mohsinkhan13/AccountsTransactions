using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Net;

namespace Azure.Infrastructure
{
    public class ServiceBus
    {
        public virtual QueueClient CreateQueue(string queueName, string queueConnectionString)
        {
            return CreateQueueIfNotExisting(queueName, queueConnectionString);
        }

        private QueueClient CreateQueueIfNotExisting(string queueName, string queueConnectionString)
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var namespaceManager = NamespaceManager.CreateFromConnectionString(queueConnectionString);
            if (!namespaceManager.QueueExists(queueName))
            {
                try
                {
                    namespaceManager.CreateQueue(queueName);

                }
                catch (MessagingEntityAlreadyExistsException)
                {
                }
            }

            return  QueueClient.CreateFromConnectionString(queueConnectionString, queueName);

        }
    }
}
