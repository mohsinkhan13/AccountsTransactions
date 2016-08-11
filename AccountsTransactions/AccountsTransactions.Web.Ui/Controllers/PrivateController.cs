using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AccountsTransactions.Web.Ui.Controllers
{
    public class PrivateController : Controller
    {
        // GET: Private
        public async Task<ActionResult> Index()
        {

            var response = await GetTokenAsync();
            //var t = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGllbnRfaWQiOiJwb3J0YWwiLCJzY29wZSI6Im9uZWNsaWNrIiwic3ViIjoiYWM2MTUyMTQtZjhkOS00ZGRmLWEzOGYtMzEyZGJiNzgxY2I1IiwiYW1yIjpbInBhc3N3b3JkIl0sImF1dGhfdGltZSI6MTQ3MDgzMzQwNSwiaWRwIjoiaWRzcnYiLCJuYW1lIjoiUG9ydGFsQWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUG9ydGFsQWRtaW4iLCJodHRwOi8vY2xhaW1zLmFkZGlzb24uZGUvbWVtYmVyZ3VpZCI6ImFjNjE1MjE0LWY4ZDktNGRkZi1hMzhmLTMxMmRiYjc4MWNiNSIsImh0dHA6Ly9jbGFpbXMuYWRkaXNvbi5kZS9tZW1iZXJuYW1lIjoiUG9ydGFsQWRtaW4iLCJodHRwOi8vY2xhaW1zLmFkZGlzb24uZGUvbWVtYmVyZmxhZ3MiOiIwIiwiaHR0cDovL2NsYWltcy5hZGRpc29uLmRlL29yZ2FuaXphdGlvbmd1aWQiOiIxMmVmNWQ2NC1kMGQ5LTRiMGItOWE3MS1hZTA0NjMyMDUzZjIiLCJodHRwOi8vY2xhaW1zLmFkZGlzb24uZGUvb3JnYW5pemF0aW9udHlwZSI6IlN0YiIsImh0dHA6Ly9jbGFpbXMuYWRkaXNvbi5kZS9vcmdhbml6YXRpb25uYW1lIjoiYm9nZGFuIiwiaHR0cDovL2NsYWltcy5hZGRpc29uLmRlL0RCQ29ubmVjdGlvbnMiOiJcdTAwM2NDb25uZWN0aW9uc1x1MDAzZVx1MDAzY2Nvbm5lY3Rpb24gbmFtZT1cInNvY2lhbG5ldHdvcmtcIiBkYj1cInBvcnRhbF9zb2NpYWxuZXR3b3JrXCIgc2VydmVyPVwiMTAuMC4wLjRcIiBpZD1cIjA0ZmVhMzJlLTkyZWMtNDBiOC04MmE5LWFkZDZkMzk0M2RkYVwiIHVzZXI9XCJzb2NpYWxuZXR3b3JrXCIgcGFzc3dvcmQ9XCIxMjNcIiAvXHUwMDNlXHUwMDNjY29ubmVjdGlvbiBuYW1lPVwiZ2F0ZXdheVwiIGRiPVwicG9ydGFsX2dhdGV3YXlcIiBzZXJ2ZXI9XCIxMC4wLjAuNFwiIGlkPVwiMTk2NWFjZmEtZWYzYy00ZmIwLWFhY2EtMDliNTFjOGNjODE3XCIgdXNlcj1cImdhdGV3YXlcIiBwYXNzd29yZD1cIjQ1NlwiIC9cdTAwM2VcdTAwM2Njb25uZWN0aW9uIG5hbWU9XCJvcmdhbml6YXRpb25cIiBkYj1cIm9yZ2FuaXphdGlvbl8xXCIgc2VydmVyPVwiMTAuMC4wLjRcIiBpZD1cIkY2MTkxQTQ4LTMwQjItNDkwRS05RkMyLTlEMjUxNzk3N0I5NVwiIHVzZXI9XCJcIiBwYXNzd29yZD1cIlwiIC9cdTAwM2VcdTAwM2Njb25uZWN0aW9uIG5hbWU9XCJtYW5hZ2VtZW50XCIgZGI9XCJwb3J0YWxfbWFuYWdlbWVudFwiIHNlcnZlcj1cIjEwLjAuMC40XCIgaWQ9XCJiZTExOTI2My01M2NkLTRmNmMtOGI1Mi01NDVjNWNkYjIxYTBcIiB1c2VyPVwibWFuYWdlbWVudFwiIHBhc3N3b3JkPVwiMTAxMTEyXCIgL1x1MDAzZVx1MDAzYy9Db25uZWN0aW9uc1x1MDAzZSIsImh0dHA6Ly9jbGFpbXMuYWRkaXNvbi5kZS9tZW1iZXJ0eXBlIjoic3RiX2FkbWluIiwiaHR0cDovL2NsYWltcy5hZGRpc29uLmRlL1Nlc3Npb25JZCI6IjFkYWNhMTg3LTgxMTAtNGYzYS1iNTNiLWVlY2I1YjJjZTAyZiIsImp0aSI6IjE5MGRlY2I3YzU2ZTc5NTkwZDMwNjVlMzIxNDlkMjhiIiwiaXNzIjoiaHR0cHM6Ly9zZXJ2aWNlcy5hZGRpc29uNTEuZGUvc2VydmljZWhvc3RzL2lkZW50aXR5c2VydmVyIiwiYXVkIjoiaHR0cHM6Ly9zZXJ2aWNlcy5hZGRpc29uNTEuZGUvc2VydmljZWhvc3RzL2lkZW50aXR5c2VydmVyL3Jlc291cmNlcyIsImV4cCI6MTQ3MDg2OTQwNiwibmJmIjoxNDcwODMzNDA2fQ.iZOJVCv5XRM2Lst-KqmRKxZ8PgPUf_Cmjv1DQAf90q8";
            var result = await CallApi(response.AccessToken);
            //var result = await CallApi(t);

            ViewBag.Json = result;
            return View();
        }
        
        private async Task<string> CallApi(string token)
        {

            // call client
            var client = new HttpClient();
            client.SetBearerToken(token);
            var json = await client.GetStringAsync("http://localhost:64666/api/world");

            return JArray.Parse(json).ToString();
        }

        private async Task<TokenResponse> GetTokenAsync()
        {

            // get token
            var client = new TokenClient(
                "https://services.oneclickuk.de/authority/connect/token",
                "portal",
                "aip_secret");
            
            return await client.RequestResourceOwnerPasswordAsync(@"bogdan\portaladmin", "123", "oneclick");
        }
    }
}