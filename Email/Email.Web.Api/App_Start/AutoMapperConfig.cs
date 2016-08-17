using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email.Web.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;
        public static void Configure()
        {
            Config = new MapperConfiguration(cfg => { });

            var profileConfig = (IConfiguration)Config;
            //AutoMapperConfiguration.Configure(profileConfig);
        }
    }
}