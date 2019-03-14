using AutoMapper;
using Screend.Entities.Movie;
using Screend.Entities.Schedule;
using Screend.Entities.Theater;
using Screend.Models.Movie;
using Screend.Models.Schedule;
using Screend.Models.Theater;

namespace Screend.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<ScheduleDTO, Schedule>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<Theater, TheaterDTO>();
            CreateMap<TheaterDTO, Theater>();
            CreateMap<TheaterRow, TheaterRowDTO>();
            CreateMap<TheaterRowDTO, TheaterRow>();
            CreateMap<TheaterChair, TheaterChairDTO>();
            CreateMap<TheaterChairDTO, TheaterChair>();
        }
    }
}