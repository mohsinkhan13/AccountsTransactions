using AutoMapper;
using Email.Common.AutoMapper.Profiles;

namespace Email.Common.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IConfiguration config)
        {
            config.AddProfile(new EmailProfile());
        }
    }
}