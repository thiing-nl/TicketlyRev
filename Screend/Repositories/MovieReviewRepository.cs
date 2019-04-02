using Screend.Data;
using Screend.Entities.Movie;

namespace Screend.Repositories
{
    public interface IMovieReviewRepository : IRepository<MovieReview>
    {
    }
    
    public class MovieReviewRepository : BaseRepository<MovieReview>, IMovieReviewRepository
    {
        private DatabaseContext _context;
        
        public MovieReviewRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}