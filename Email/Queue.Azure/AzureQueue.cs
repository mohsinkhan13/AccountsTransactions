using System;
using Email.DomainModel;
using System.Net;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;
using ConfigurationManager;
using Queue.Contracts;

namespace Queue.Azure
{
    public class AzureQueue<T> : IQueue<T> where T : Message
    {
        private string _queueName;
        private string _queueConnectionString;
        private QueueClient _client;

        public AzureQueue()
        {
            _queueName = Config.ServiceBusQueueName;
            _queueConnectionString = Config.ServiceBusQueueConnectionString;
            CreateQueueIfNotExisting();
        }

        private void CreateQueueIfNotExisting()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var namespaceManager = NamespaceManager.CreateFromConnectionString(_queueConnectionString);
            if (!namespaceManager.QueueExists(_queueName))
            {
                try
                {
                    namespaceManager.CreateQueue(_queueName);

                }
                catch (MessagingEntityAlreadyExistsException exception)
                {
                }
                
            }

            _client = QueueClient.CreateFromConnectionString(_queueConnectionString, _queueName);

        }

        public void Enqueue(T message)
        {
            var brokeredMessage = new BrokeredMessage(message, new DataContractSerializer(typeof(T)));
            _client.Send(brokeredMessage);
        }

        
        public void Dispose()
        {
            _client.Close();
        }
    }
}
