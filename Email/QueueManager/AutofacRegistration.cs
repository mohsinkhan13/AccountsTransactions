using Autofac;
using Queue.Azure;
using Queue.Contracts;

namespace Email.QueueManager
{
    public static class AutofacRegistration
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AzureQueue>().As<IQueue>().PropertiesAutowired();
            return builder.Build();

        }
    }
}
