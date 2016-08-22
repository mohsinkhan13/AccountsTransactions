using System.Diagnostics;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;
using Email.QueueManager;

namespace Email.CloudService.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        string _queueName;
        string _queueConnectionString;

        IQueueProcessor _queueProcessor;
        ManualResetEvent CompletedEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.WriteLine("Starting processing of messages");

            _queueProcessor.Client.OnMessage((receivedMessage) =>
                {
                    try
                    {
                        _queueProcessor.ProcessQueueMessage(receivedMessage);
                        //notify other parties

                    }
                    catch
                    {
                        // Handle any message processing specific exceptions here
                    }
                });
                        
            CompletedEvent.WaitOne();
        }

        public override bool OnStart()
        {
            //TODO IOC
            _queueName = ConfigurationManager.AppSettings["QueueName"] ?? "";
            _queueConnectionString = ConfigurationManager.AppSettings["QueueConnectionString"] ?? "";
            _queueProcessor = new AzureQueueProcessor(_queueConnectionString, _queueName);
            return base.OnStart();
        }

        

        public override void OnStop()
        {
            // Close the connection to Service Bus Queue
            _queueProcessor.Client.Close();
            CompletedEvent.Set();
            base.OnStop();
        }
    }
}
