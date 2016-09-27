using System;
using Email.DomainModel;
using System.Net;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;
using ConfigurationManager;
using Queue.Contracts;
using Azure.Infrastructure;
using System.Collections.Generic;

namespace Queue.Azure
{
    public class AzureQueue<T> : IQueue<T> where T : Message
    {
        private string _queueName;
        private string _queueConnectionString;
        private QueueClient _client;

        public AzureQueue(ServiceBus serviceBus)
        {
            _queueName = Config.ServiceBusQueueName;
            _queueConnectionString = Config.ServiceBusQueueConnectionString;
            _client = serviceBus.CreateQueue(_queueName, _queueConnectionString);
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
