using Screend.Data;
using Screend.Entities.Ticket;

namespace Screend.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
    }
    
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private DatabaseContext _context;
        
        public TicketRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}