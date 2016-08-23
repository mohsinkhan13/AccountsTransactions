using System;
using Email.DomainModel;
using System.Net;
using Microsoft.ServiceBus;
using System.Configuration;
using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("AutoFac")]
namespace Email.QueueManager
{
    public class AzureQueue : IQueue
    {
        private string _queueName;
        private string _queueConnectionString;
        private QueueClient _client;

        Action<EmailMessage> callback = new Action<EmailMessage>((emailMessage) => { });
        public AzureQueue()
        {
            _queueName = ConfigurationManager.AppSettings["QueueName"] ?? "";
            _queueConnectionString = ConfigurationManager.AppSettings["QueueConnectionString"] ?? "";
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
                //any other exceptions to be logged
                
            }

            _client = QueueClient.CreateFromConnectionString(_queueConnectionString, _queueName);

        }

        public void Put(EmailMessage message)
        {
            var brokeredMessage = new BrokeredMessage(message, new DataContractSerializer(typeof(Email.DomainModel.EmailMessage)));
            _client.Send(brokeredMessage);
        }

        public void DefineMessageCallback(Action<EmailMessage> action)
        {
            _client.OnMessage((receivedMessage) => 
                {
                    var body = receivedMessage.GetBody<EmailMessage>(new DataContractSerializer(typeof(EmailMessage)));

                    action(body);
                });
        }

        public void Dispose()
        {
            _client.Close();
        }
    }
}
