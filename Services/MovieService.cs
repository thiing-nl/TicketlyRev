using Screend.Repositories;

namespace Screend.Services
{
    public interface IMovieService
    {
    }
    
    public class MovieService : BaseService, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
    }
}