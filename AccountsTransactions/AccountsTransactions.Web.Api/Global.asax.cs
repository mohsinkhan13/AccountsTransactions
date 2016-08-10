using AccountsTransactions.Web.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AccountsTransactions.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AuthConfig.Register(GlobalConfiguration.Configuration);
            AuthConfig.Register(GlobalConfiguration.Configuration);

        }
    }
}
