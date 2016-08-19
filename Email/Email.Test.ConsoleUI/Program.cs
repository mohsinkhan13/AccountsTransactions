using Email.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Runtime.Serialization;

namespace Email.Test.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ISendable service = new SendGridEmailService("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");

            //service.Send(new EmailMessage
            //{
            //    From = "mohsin.khan@wolterskluwer.com",
            //    To = new List<string> { "mohsin.khan@wolterskluwer.com" },
            //    EmailContent = "Test content from test console UI",
            //    ContentType = EmailContentType.TextHtml,
            //    Subject = "Test Subject from test console UI"

            //});


            ////send message
            var connectionString = "Endpoint=sb://wkemailservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8/Du+d6qMBX96ZF+jAg0XB/zGoN1CoEq5ss481xIp9Y=";
            var queueName = "emailmessagequeue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            var email = new Email.DomainModel.EmailMessage
            {
                From = "mohsin.khan@wolterskluwer.com",
                To = new List<string> { "mohsink13@gmail.com" },
                EmailContent = "Test content from test console UI",
                ContentType = EmailContentType.TextHtml,
                Subject = "Test Subject from test console UI"
            };

            //var message = new BrokeredMessage(email, new DataContractSerializer(typeof(Email.DomainModel.EmailMessage)));// ("this is a string message...");
            var message = new BrokeredMessage(email, new DataContractSerializer(typeof(Email.DomainModel.EmailMessage)));// ("this is a string message...");
            client.Send(message);


            //reading message
            //var connectionString = "Endpoint=sb://wkemailservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8/Du+d6qMBX96ZF+jAg0XB/zGoN1CoEq5ss481xIp9Y=";
            //var queueName = "emailmessagequeue";

            //var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            ////string body = "";
            //var body = new Email.DomainModel.EmailMessage();
            //client.OnMessage(message =>
            //{
            //    //Console.WriteLine(String.Format("Message body: {0}", message.GetBody<EmailMessage>()));
            //    //Console.WriteLine(String.Format("Message id: {0}", message.MessageId));

            //    body = message.GetBody<Email.DomainModel.EmailMessage>(new DataContractSerializer(typeof(Email.DomainModel.EmailMessage)));
            //    Console.WriteLine(body.From);
            //    Console.WriteLine(body.EmailContent);

            //});

            //Console.ReadLine();


            Console.Read();
        }
    }
}
