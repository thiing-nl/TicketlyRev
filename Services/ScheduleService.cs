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
            
            return _scheduleRepository.Get(it => it.Time > date && it.Time < end && it.LocationId == locationId).ToArray();
        }

        public ICollection<Schedule> GetByMovie(int movieId, int locationId)
        {
            DateTime now = DateTime.Now;
            DateTime end = DateTime.Today.AddDays(7);
            var schedules = _scheduleRepository
                .Get(it => it.Movie.Id == movieId && 
                           it.Time > now && 
                           it.Time < end && 
                           it.LocationId == locationId)
                .OrderBy(it => it.Time)
                .ToArray();

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