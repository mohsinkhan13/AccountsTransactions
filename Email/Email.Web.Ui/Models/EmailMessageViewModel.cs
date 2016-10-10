using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email.Web.Ui.Models
{
    public class EmailMessageViewModel
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string EmailContent { get; set; }
        public string ContentType { get; set; }


    }
}