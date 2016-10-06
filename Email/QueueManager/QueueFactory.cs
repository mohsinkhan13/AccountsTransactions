using Autofac;
using Email.DomainModel;
using Queue.Contracts;

namespace Email.QueueManager
{
    public static class QueueFactory
    {
        private static IContainer _container;
        static QueueFactory()
        {
            _container = AutofacRegistration.Register();
        }

        public static IQueue<T> GetQueue<T>() where T : Message
        {
            return _container.Resolve<IQueue<T>>();
        }
    }
}
