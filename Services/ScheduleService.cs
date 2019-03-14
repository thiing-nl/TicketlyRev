using System;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Schedule;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IScheduleService
    {

        ICollection<Schedule> GetByDay(DateTime date);

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
            DateTime end = date.AddDays(1);
            return _scheduleRepository.Get(it => it.Time > date && it.Time < end).ToArray();
        }
        
    }
}