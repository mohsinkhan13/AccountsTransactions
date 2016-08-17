using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Email.Web.Api.App_Start
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            //var builder = new ContainerBuilder();

            //builder.Register(c => AutoMapperConfig.Config.CreateMapper()).As<IMapper>();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //AutofacRegistration.Register(builder);

            //var container = builder.Build();

            //var resolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}