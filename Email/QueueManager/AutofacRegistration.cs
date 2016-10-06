using Autofac;
using Azure.Infrastructure;
using Email.DomainModel;
using Queue.Azure;
using Queue.Contracts;

namespace Email.QueueManager
{
    public static class AutofacRegistration
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AzureQueue<EmailMessage>>()
                   .As<IQueue<EmailMessage>>()
                   //.WithParameter("serviceBus",new ServiceBus())
                   .WithParameter(new TypedParameter(typeof(ServiceBus), new ServiceBus()))
                    ;
            return builder.Build();

        }
    }
}
