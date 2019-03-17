using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Location;
using Screend.Entities.Movie;
using Screend.Exceptions;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IMovieService
    {
        ICollection<Movie> GetAllMoviesByLocation(int locationId);
        Movie Get(int id);
        void Delete(int id);
    }
    
    public class MovieService : BaseService, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILocationRepository _locationRepository;

        public MovieService(IMovieRepository movieRepository, ILocationRepository locationRepository)
        {
            _movieRepository = movieRepository;
            _locationRepository = locationRepository;
        }

        public ICollection<Movie> GetAllMoviesByLocation(int locationId)
        {
            var location = _locationRepository.GetByID(locationId);
            
            return location.Movies.Select(it => it.Movie).ToArray();
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