using Email.Services;
using System;
using System.Collections.Generic;
using Email.QueueManager;

namespace Email.Test.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var qm = QueueFactory.GetQueue();

            var email = new Email.DomainModel.EmailMessage
            {
                From = "mohsin.khan@wolterskluwer.com",
                To = new List<string> { "mohsink13@gmail.com" },
                EmailContent = "Test content from test console UI",
                ContentType = EmailContentType.TextHtml,
                Subject = "Test email using QueueFactory Azure Queue!!!"
            };

            qm.Put(email);

            Console.Read();
        }
    }
}
