using Autofac;
using Email.Services;

namespace Email.Common.Autofac
{
    public static class AutofacRegistration
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(QueueService<>))
                .As(typeof(IQueueService<>))
                .InstancePerDependency();

            builder.RegisterType<EmailService>()
                .As<IEmailService>().PropertiesAutowired();

        }
    }
}
