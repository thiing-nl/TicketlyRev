using Screend.Data;
using Screend.Entities.Movie;
using Screend.Entities.Order;
using Screend.Entities.Theater;

namespace Screend.Repositories
{
    public interface ITheaterRepository : IRepository<Theater>
    {
    }
    
    public class TheaterRepository : BaseRepository<Theater>, ITheaterRepository
    {
        private DatabaseContext _context;
        
        public TheaterRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}