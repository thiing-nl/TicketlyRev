using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Location;
using Screend.Entities.Schedule;
using Screend.Exceptions;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IScheduleService
    {
        ICollection<Schedule> GetByDay(DateTime date, int locationId);
        ICollection<Schedule> GetByWeek(DateTime date, int locationId);
        ICollection<Schedule> GetByMovie(int movieId, int locationId);
        Schedule GetById(int id);
    }
    
    public class ScheduleService : BaseService, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
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
    }
}