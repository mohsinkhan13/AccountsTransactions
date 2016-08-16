using System.Net.Http;
using System.Web.Http;

namespace Email.Web.Api.Controllers
{
    [Route("api/world")]
    [Authorize]
    public class WorldController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Greeting()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent("Hello World ! ! !")
            };
        }
    }
}
