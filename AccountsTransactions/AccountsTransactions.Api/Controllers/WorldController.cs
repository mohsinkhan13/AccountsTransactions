using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountsTransactions.Api.Controllers
{
    [Route("api/world")]
    [Authorize]
    public class WorldController : ApiController
    {
        [HttpGet]
        public string Greeting()
        {
            return "Hello World ! ! !";
        }
    }
}
