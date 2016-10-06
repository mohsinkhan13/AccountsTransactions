using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class Config
    {
        public static string ServiceBusConnectionString {
            get { return System.Configuration.ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"] ?? string.Empty; }
        }

        public static string SendGridApiKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["apikey"] ?? string.Empty; }
        }

        public static string ServiceBusQueueName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["QueueName"] ?? string.Empty; }
        }

        public static string ServiceBusQueueConnectionString
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["QueueConnectionString"] ?? string.Empty; }
        }
    }
}
