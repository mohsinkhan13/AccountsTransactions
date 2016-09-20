using Autofac;
using System;

namespace Email.QueueManager
{
    public static class QueueFactory
    {
        private static IContainer _container;
        static QueueFactory()
        {
            _container = AutofacRegistration.Register();
        }

        public static IQueue GetQueue()
        {
            return _container.Resolve<IQueue>();
        }
    }
}
