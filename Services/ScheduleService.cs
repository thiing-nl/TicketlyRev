using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Schedule;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IScheduleService
    {

        ICollection<Schedule> GetByDay(DateTime date);

        ICollection<Schedule> GetByMovie(int movieId);
    }
    
    public class ScheduleService : BaseService, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ICollection<Schedule> GetByDay(DateTime date)
        {
            var next = date.AddDays(1);
            DateTime end = new DateTime(
                next.Year,
                next.Month,
                next.Day
                );
            
            return _scheduleRepository.Get(it => it.Time > date && it.Time < end).ToArray();
        }

        public ICollection<Schedule> GetByMovie(int movieId)
        {
            DateTime today = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(7);
            return _scheduleRepository
                .Get(it => it.Movie.Id == movieId && it.Time > today && it.Time < end)
                .OrderBy(it => it.Time)
                .ToArray();
        }
    }
}