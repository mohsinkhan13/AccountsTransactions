using Autofac;
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
            builder.RegisterType<AzureQueue<EmailMessage>>().As<IQueue<EmailMessage>>().PropertiesAutowired();
            return builder.Build();

        }
    }
}
