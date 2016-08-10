using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountsTransactions.Web.Api.Controllers
{
    public class WorldController : ApiController
    {
        [HttpGet]
        //[Authorize]
        public string Greeting()
        {
            return "Hello World ! ! !";
        }
    }
}
