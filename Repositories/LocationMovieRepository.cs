using Screend.Data;
using Screend.Entities.Location;

namespace Screend.Repositories
{
    public interface ILocationMovieRepository: IRepository<LocationMovie>
    {
    }
    
    public class LocationMovieRepository : BaseRepository<LocationMovie>, ILocationMovieRepository
    {
        private DatabaseContext _context;
        
        public LocationMovieRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}