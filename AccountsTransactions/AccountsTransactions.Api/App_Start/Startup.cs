using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;
using System.Security.Claims;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Serilog;

[assembly: OwinStartup(typeof(AccountsTransactions.Api.App_Start.Startup))]

namespace AccountsTransactions.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // resource server
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = "https://services.oneclickuk.de/authority",
                RequiredScopes = new[] { "oneclick" }
            });

           
            // web api configuration
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }
    }
}
