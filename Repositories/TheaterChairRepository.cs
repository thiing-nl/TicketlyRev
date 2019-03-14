using Screend.Data;
using Screend.Entities.Theater;

namespace Screend.Repositories
{
    public interface ITheaterChairRepository : IRepository<TheaterChair>
    {}
    
    public class TheaterChairRepository : BaseRepository<TheaterChair>, ITheaterChairRepository
    {
        private readonly DatabaseContext _context;
        
        public TheaterChairRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}