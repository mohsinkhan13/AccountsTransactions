using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Email.Web.Api.Models;

namespace Email.Web.Api.Controllers
{
    [Route("api/email")]
    [Authorize]
    public class EmailController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent("This is email api !!!")
            };
        }
    }

    public interface IEmailAccessor
    {
        EmailModel GetEmail(Guid emailId);
        void Send(EmailModel email);
    }

    public class EmailAccessor : IEmailAccessor
    {
        public EmailModel GetEmail(Guid emailId)
        {
            throw new NotImplementedException();
        }

        public void Send(EmailModel email)
        {
            throw new NotImplementedException();
        }
    }


    public interface IQueueService<T> where T : class
    {
        void AddToQueue(T item);
        T RetriveFromQueue();
    }

    public class QueueService<T> : IQueueService<T> where T : class
    {
        private List<T> _queue;

        public List<T> Queue
        {
            get
            {
                return _queue;
            }

            set
            {
                _queue = value;
            }
        }

        public QueueService()
        {
            _queue = new List<T>();
        }

        public void AddToQueue(T item)
        {
            _queue.Add(item);
        }

        public T RetriveFromQueue()
        {
            var item = _queue[0];
            _queue.RemoveAt(0);

            return item;
        }
    }


    
}
