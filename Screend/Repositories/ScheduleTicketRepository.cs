using Screend.Data;
using Screend.Entities.Schedule;

namespace Screend.Repositories
{
    public interface IScheduleTicketRepository : IRepository<ScheduleTicket>
    {
    }
    
    public class ScheduleTicketRepository : BaseRepository<ScheduleTicket>, IScheduleTicketRepository
    {
        private DatabaseContext _context;
        
        public ScheduleTicketRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}