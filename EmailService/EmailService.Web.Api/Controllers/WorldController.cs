using System.Net.Http;
using System.Web.Http;

namespace EmailService.Web.Api.Controllers
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
