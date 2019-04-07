using AutoMapper;
using Screend.Profiles;

namespace Screend.Tests
{
    public class Helper
    {
        private static bool Initialized = false;
        public static void SetupAutoMapper()
        {
            if (!Initialized)
            {
                Initialized = true;
                Mapper.Reset();
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
}