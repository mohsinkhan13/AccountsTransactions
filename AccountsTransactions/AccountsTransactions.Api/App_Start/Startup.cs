using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Collections.Generic;
using System;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(AccountsTransactions.Api.App_Start.Startup))]

namespace AccountsTransactions.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                Realm = "https://addison.addison51.de/",
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningTokens = new List<SecurityToken>
                    {
                        new BinarySecretSecurityToken(
                            Convert.FromBase64String("o5Tjl+j6pTjQJR9PdZ1fpSyQAgebeXudG3pBw91GFv4=")),
                    },
                    ValidAudiences = new List<string>{
                        "https://services.addison51.de/servicehosts/identityserver/resources"
                    },
                    ValidIssuer = "https://services.addison51.de/servicehosts/identityserver"

                }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }
    }
}
