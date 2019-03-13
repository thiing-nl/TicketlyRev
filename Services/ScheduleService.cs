using Screend.Repositories;

namespace Screend.Services
{
    public interface IScheduleService
    {
    }
    
    public class ScheduleService : BaseService, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
    }
}