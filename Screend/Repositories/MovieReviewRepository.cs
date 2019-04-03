using System.Collections.Generic;
using System.Linq;
using Screend.Data;
using Screend.Entities.Movie;

namespace Screend.Repositories
{
    public interface IMovieReviewRepository : IRepository<MovieReview>
    {
        ICollection<MovieReview> GetReviewsByMovieId(int movieId);
    }
    
    public class MovieReviewRepository : BaseRepository<MovieReview>, IMovieReviewRepository
    {
        private DatabaseContext _context;
        
        public MovieReviewRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<MovieReview> GetReviewsByMovieId(int movieId)
        {
            return Get(mr => mr.MovieId == movieId).ToArray();
        }
    }
}