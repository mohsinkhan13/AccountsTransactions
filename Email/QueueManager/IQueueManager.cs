using Email.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.QueueManager
{
    public interface IQueueManager
    {
        void Put(EmailMessage message);
        void DefineMessageCallback(Action<EmailMessage> action);
    }
}
