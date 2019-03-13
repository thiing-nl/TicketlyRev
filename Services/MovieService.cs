using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Movie;
using Screend.Exceptions;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IMovieService
    {
        ICollection<Movie> GetAll();
        Movie Get(int id);
        void Delete(int id);
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
            var movie = _movieRepository.GetByID(id);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            return movie;
        }

        public void Delete(int id)
        {
            var movie = Get(id);
            _movieRepository.Delete(movie);
            _movieRepository.Commit();
        }
        
    }
}