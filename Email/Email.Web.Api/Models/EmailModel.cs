using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email.Web.Api.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public List<string> To { get; set; }

        public string EmailBody { get; set; }

    }
}