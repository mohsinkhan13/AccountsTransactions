using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
