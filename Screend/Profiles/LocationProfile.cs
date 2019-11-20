using AutoMapper;
using Screend.Entities.Location;
using Screend.Models.Location;

namespace Screend.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDTO>()
                .ReverseMap();
            CreateMap<Location, LocationMinimalDTO>()
                .ReverseMap();
        }
    }
}