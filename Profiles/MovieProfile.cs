using AutoMapper;
using Screend.Entities.Schedule;
using Screend.Models.Movie;

namespace Screend.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieScheduleDTO, Schedule>();
            CreateMap<Schedule, MovieScheduleDTO>();
        }
    }
}