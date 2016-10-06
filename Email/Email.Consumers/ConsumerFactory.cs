using Email.Contracts;
using Email.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Email.Consumers
{
    public class ConsumerFactory
    {

        public IMessageConsumer<T> GetConsumer<T>(ISendable<T> service) where T : Message
        {
            var consumers = GetConsumerTypes<T>().ToList();

            var consumer = consumers.Select(handler =>
                (IMessageConsumer<T>)Activator.CreateInstance(handler,new[] { service })).FirstOrDefault();

            return consumer;
        }

        private IEnumerable<Type> GetConsumerTypes<T>() where T : Message
        {
            var consumerss = this.GetType().Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IMessageConsumer<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();

            return consumerss;
        }
    }
}
