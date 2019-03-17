using AutoMapper;
using Screend.Entities.Schedule;
using Screend.Models.Movie;

namespace Screend.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Schedule, MovieScheduleDTO>()
                .ReverseMap();
        }
    }
}