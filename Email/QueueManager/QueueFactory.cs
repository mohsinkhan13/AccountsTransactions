using Autofac;
using System;

namespace Email.QueueManager
{
    public static class QueueFactory
    {
        private static IContainer _container;
        static QueueFactory()
        {
            var container = new ContainerBuilder();
            _container = LoadBindings(container);
        }

        private static IContainer LoadBindings(ContainerBuilder container)
        {
            container.RegisterType<AzureQueue>().As<IQueue>().PropertiesAutowired();
            return container.Build();
        }
        
        public static IQueue GetQueue()
        {
            return _container.Resolve<IQueue>();
        }
    }
}
