using Screend.Data;
using Screend.Entities.Schedule;

namespace Screend.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
    }
    
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        private DatabaseContext _context;
        
        public ScheduleRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}