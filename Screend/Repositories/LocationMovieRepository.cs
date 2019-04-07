using Screend.Data;
using Screend.Entities.Location;

namespace Screend.Repositories
{
    public interface ILocationMovieRepository: IRepository<LocationMovie>
    {
        LocationMovie GetLocationMovieByLocationIdAndMovieId(int locationId, int movieId);
    }
    
    public class LocationMovieRepository : BaseRepository<LocationMovie>, ILocationMovieRepository
    {
        private DatabaseContext _context;
        
        public LocationMovieRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public LocationMovie GetLocationMovieByLocationIdAndMovieId(int locationId, int movieId)
        {
            return FirstOrDefault(it => 
                it.MovieId == movieId && it.LocationId == locationId
            );
        }
    }
}