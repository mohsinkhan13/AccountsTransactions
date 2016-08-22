using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;
using System;
using Email.DomainModel;
using Email.QueueManager;

namespace Email.CloudService.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        string _queueName;
        string _queueConnectionString;

        ManualResetEvent CompletedEvent = new ManualResetEvent(false);

        Action<EmailMessage> callback = new Action<EmailMessage>(emailMessage => {
            var consumer = new SendEmailMessageConsumer();
            consumer.Consume(emailMessage);
        });

        //delegate void Action<EmailMessage> 


        public override void Run()
        {
            using (var manager = new AzureQueueManager())
            {
                manager.DefineMessageCallback(callback);
                CompletedEvent.WaitOne();
            }
        }

        public override bool OnStart()
        {
            //TODO IOC
            _queueName = ConfigurationManager.AppSettings["QueueName"] ?? "";
            _queueConnectionString = ConfigurationManager.AppSettings["QueueConnectionString"] ?? "";
            return base.OnStart();
        }

        

        public override void OnStop()
        {
            CompletedEvent.Set();
            base.OnStop();
        }
    }
}
