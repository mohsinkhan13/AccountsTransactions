using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using Email.DomainModel;
using Email.Services;
using ConfigurationManager;
using Email.Contracts;
using Email.Consumers;
using System.Net;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;

namespace Email.CloudService.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        
        ManualResetEvent CompletedEvent = new ManualResetEvent(false);
        private string _queueName;
        private string _queueConnectionString;
        private QueueClient _client;
        
        public override void Run()
        {
            
            _client.OnMessage((receivedMessage) =>
            {
                var body = receivedMessage.GetBody<EmailMessage>(new DataContractSerializer(typeof(EmailMessage)));

                IMessageConsumer<EmailMessage> consumer = new ConsumerFactory().GetConsumer(new SendGridEmailService(Config.SendGridApiKey));
                consumer.Consume(body);
            });

            CompletedEvent.WaitOne();
        }

        public override bool OnStart()
        {
            _queueName = Config.ServiceBusQueueName;
            _queueConnectionString = Config.ServiceBusQueueConnectionString;
            CreateQueueIfNotExisting();
            return base.OnStart();
        }

        public override void OnStop()
        {
            CompletedEvent.Set();
            _client.Close();
            base.OnStop();
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
    }
}
