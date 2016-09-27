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
using Azure.Infrastructure;
using Queue.Azure;

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

            _client = new ServiceBus().CreateQueue(_queueName, _queueConnectionString);

            return base.OnStart();
        }

        public override void OnStop()
        {
            CompletedEvent.Set();
            _client.Close();
            base.OnStop();
        }
    }
}
