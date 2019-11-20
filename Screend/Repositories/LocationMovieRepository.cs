using Screend.Data;
using Screend.Entities.Location;

namespace Screend.Repositories
{
    public interface ILocationMovieRepository: IRepository<LocationMovie>
    {
        LocationMovie GetByMovieIdAndLocationId(int movieId, int locationId);
    }
    
    public class LocationMovieRepository : BaseRepository<LocationMovie>, ILocationMovieRepository
    {
        private DatabaseContext _context;
        
        public LocationMovieRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public LocationMovie GetByMovieIdAndLocationId(int movieId, int locationId)
        {
            return FirstOrDefault(it => it.MovieId == movieId && it.LocationId == locationId);
        }
    }
}