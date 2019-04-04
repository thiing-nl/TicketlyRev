using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Location;
using Screend.Entities.Order;
using Screend.Entities.Schedule;
using Screend.Exceptions;
using Screend.Models.Schedule;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IScheduleService
    {
        ICollection<Schedule> GetAll();
        ICollection<Schedule> GetByDay(DateTime date, int locationId);
        ICollection<Schedule> GetByWeek(DateTime date, int locationId);
        ICollection<Schedule> GetByMovie(int movieId, int locationId);
        Schedule GetById(int id);
        Schedule CreateSchedule(ScheduleCreateDTO scheduleCreateDto, Location location);
    }
    
    public class ScheduleService : BaseService, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ITheaterRepository _theaterRepository;
        private readonly IMovieRepository _movieRepository;
        
        public ScheduleService(
            IScheduleRepository scheduleRepository,
            ITheaterRepository theaterRepository,
            IMovieRepository movieRepository
        )
        {
            _scheduleRepository = scheduleRepository;
            _theaterRepository = theaterRepository;
            _movieRepository = movieRepository;
        }

        public ICollection<Schedule> GetAll()
        {
            return _scheduleRepository.GetAll().ToArray();
        }

        public ICollection<Schedule> GetByDay(DateTime date, int locationId)
        {
            var next = date.AddDays(1);
            DateTime end = new DateTime(
                next.Year,
                next.Month,
                next.Day
                );
            
            return _scheduleRepository.GetSchedulesByDateRangeAndLocationId(date, end, locationId);
        }
        
        public ICollection<Schedule> GetByWeek(DateTime date, int locationId)
        {
            var next = date.AddDays(7);
            DateTime end = new DateTime(
                next.Year,
                next.Month,
                next.Day
            );

            return _scheduleRepository.GetSchedulesByDateRangeAndLocationId(date, end, locationId);
        }

        public ICollection<Schedule> GetByMovie(int movieId, int locationId)
        {
            DateTime now = DateTime.Now;
            DateTime end = DateTime.Today.AddDays(7);
            var schedules =
                _scheduleRepository.GetSchedulesByDateRangeAndLocationIdAndMovieId(
                    now, end, locationId, movieId
                    );
            return schedules;
        }

        public Schedule GetById(int id)
        {
            var schedule = _scheduleRepository.GetByID(id);

            if (schedule == null)
            {
                throw new NotFoundException("Schedule not found");
            }

            return schedule;
        }

        public Schedule CreateSchedule(ScheduleCreateDTO scheduleCreateDto, Location location)
        {
            var movie = _movieRepository.GetByID(scheduleCreateDto.MovieId);
            var theater = _theaterRepository.GetByID(scheduleCreateDto.TheaterId);
            
            if (movie == null || theater == null)
            {
                throw new NotFoundException("Movie or Theater not found");
            }

            var schedule = new Schedule
            {
                Movie = movie,
                Theater = theater,
                Time = scheduleCreateDto.Time,
                Location = location,
                OrderChairs = new List<OrderChair>(),
                ScheduleTickets = new List<ScheduleTicket>()
            };
                
            _scheduleRepository.Insert(schedule);
            _scheduleRepository.Commit();

            return schedule;
        }
    }
}