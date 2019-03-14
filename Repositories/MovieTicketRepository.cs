using Screend.Data;
using Screend.Entities.Movie;

namespace Screend.Repositories
{
    public interface IMovieTicketRepository : IRepository<MovieTicket>
    {
    }
    
    public class MovieTicketRepository : BaseRepository<MovieTicket>, IMovieTicketRepository
    {
        private DatabaseContext _context;
        
        public MovieTicketRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}