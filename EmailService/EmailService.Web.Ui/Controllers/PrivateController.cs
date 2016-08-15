using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmailService.Web.Ui.Controllers
{
    public class PrivateController : Controller
    {
        public async Task<ActionResult> Index()
        {

            var response = await GetTokenAsync();
            var result = await CallApi(response.AccessToken);
            return Content(result);
        }

        private async Task<string> CallApi(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var result = await client.GetStringAsync("http://localhost:64666/api/world");

            return result;
        }

        private async Task<TokenResponse> GetTokenAsync()
        {
            var client = new TokenClient(
                "https://services.oneclickuk.de/servicehosts/authority/connect/token",
                "portal",
                "aip_secret");
            
            return await client.RequestResourceOwnerPasswordAsync(@"bogdan\portaladmin", "123", "oneclick");
        }
    }
}