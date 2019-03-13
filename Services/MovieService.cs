using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Movie;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IMovieService
    {
        ICollection<Movie> GetAll();
        Movie Get(int id);
    }
    
    public class MovieService : BaseService, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public ICollection<Movie> GetAll()
        {
            return _movieRepository.GetAll().ToArray();
        }

        public Movie Get(int id)
        {
            return _movieRepository.GetByID(id);
        }
        
    }
}