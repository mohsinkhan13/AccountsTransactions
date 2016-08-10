using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(AccountsTransactions.Web.Api.App_Start.Startup))]

namespace AccountsTransactions.Web.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://services.oneclickuk.de/authority/",
                ClientId = "portal",
                ClientSecret = "aip_secret"

            });



        }
    }
}
