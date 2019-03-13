using Screend.Data;
using Screend.Entities.Movie;
using Screend.Entities.Order;

namespace Screend.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
    
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private DatabaseContext _context;
        
        public MovieRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}