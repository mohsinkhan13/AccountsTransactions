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

        Action<EmailMessage> _callback = new Action<EmailMessage>(emailMessage => {
            var consumer = new SendEmailMessageConsumer();
            consumer.Consume(emailMessage);
        });

        public override void Run()
        {
            using (var manager = QueueFactory.GetQueue())
            {
                manager.DefineMessageCallback(_callback);
                CompletedEvent.WaitOne();
            }
        }

        public override bool OnStart()
        {
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
