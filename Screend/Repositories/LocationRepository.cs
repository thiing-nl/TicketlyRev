using Screend.Entities.Location;
using Screend.Data;
using Screend.Entities.Movie;
using Screend.Entities.Order;

namespace Screend.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
    }
    
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private DatabaseContext _context;
        
        public LocationRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}