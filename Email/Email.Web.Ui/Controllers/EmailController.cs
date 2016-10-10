using ConfigurationManager;
using Email.DomainModel;
using Email.QueueManager;
using Email.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Email.Web.Ui.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Compose()
        {
            return View(new EmailMessageViewModel());
        }

        [HttpPost]
        public ActionResult Compose(EmailMessageViewModel message)
        {
            var name = Config.ServiceBusQueueName;
            using (var qm = QueueFactory.GetQueue<EmailMessage>())
            {
                var email = new EmailMessage
                {
                    From = message.From,
                    To = new List<string> { message.To },
                    EmailContent = message.EmailContent,
                    ContentType = EmailContentType.TextHtml,
                    Subject = message.Subject
                };

                qm.Enqueue(email);
            }
            TempData["message"] = "Message sent !!!";
            return RedirectToRoute(new { action="compose", controller="email" });
        }
    }
}