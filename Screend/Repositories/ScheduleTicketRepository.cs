using System.Collections.Generic;
using System.Linq;
using Screend.Data;
using Screend.Entities.Schedule;
using Screend.Entities.Ticket;

namespace Screend.Repositories
{
    public interface IScheduleTicketRepository : IRepository<ScheduleTicket>
    {
        ICollection<ScheduleTicket> GetTicketsByScheduleId(int scheduleId);
    }
    
    public class ScheduleTicketRepository : BaseRepository<ScheduleTicket>, IScheduleTicketRepository
    {
        private DatabaseContext _context;
        
        public ScheduleTicketRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<ScheduleTicket> GetTicketsByScheduleId(int scheduleId)
        {
            return Get(st => st.ScheduleId == scheduleId).ToArray();
        }
    }
}