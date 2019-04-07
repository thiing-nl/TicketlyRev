using AutoMapper;
using Screend.Profiles;

namespace Screend.Tests
{
    public class Helper
    {
        public static void SetupAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AddProfiles(typeof(UserProfile).Assembly);
                cfg.AddProfiles(typeof(ScheduleProfile).Assembly);
                cfg.AddProfiles(typeof(MovieProfile).Assembly);
                cfg.AddProfiles(typeof(LostItemProfile).Assembly);
                cfg.AddProfiles(typeof(LocationProfile).Assembly);
            });
        }
    }
}