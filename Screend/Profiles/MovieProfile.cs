using AutoMapper;
using Screend.Entities.Movie;
using Screend.Entities.Schedule;
using Screend.Models.Movie;

namespace Screend.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            CreateMap<Schedule, MovieScheduleDTO>().ReverseMap();
        }
    }
}