using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Screend.Entities.Location;
using Screend.Entities.Movie;
using Screend.Exceptions;
using Screend.Models.Movie;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IMovieService
    {
        ICollection<Movie> GetAllMoviesByLocation(int locationId);
        Movie Get(int id);
        Movie CreateMovie(MovieCreateDTO movieCreateDto);
        MovieReview CreateMovieReview(MovieReviewCreateDTO movieReviewCreateDto, int movieId);
        ICollection<MovieReview> GetMovieReviewsByMovieId(int movieId);
        void Delete(int id);
    }
    
    public class MovieService : BaseService, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMovieReviewRepository _movieReviewRepository;
        private readonly ILocationMovieRepository _locationMovieRepository;

        public MovieService(
            IMovieRepository movieRepository, 
            ILocationRepository locationRepository,
            IMovieReviewRepository movieReviewRepository,
            ILocationMovieRepository locationMovieRepository
            )
        {
            _movieRepository = movieRepository;
            _locationRepository = locationRepository;
            _movieReviewRepository = movieReviewRepository;
            _locationMovieRepository = locationMovieRepository;
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

        public Movie CreateMovie(MovieCreateDTO movieCreateDto)
        {
            var movie = Mapper.Map<Movie>(movieCreateDto);
            _movieRepository.Insert(movie);
            _movieRepository.Commit();

            var locationMovie = new LocationMovie
            {
                Movie = movie,
                LocationId = 1
            };
            
            var locationMovie2 = new LocationMovie
            {
                Movie = movie,
                LocationId = 2
            };
            
            _locationMovieRepository.Insert(locationMovie);
            _locationMovieRepository.Insert(locationMovie2);
            _locationMovieRepository.Commit();
            return movie;
        }

        public MovieReview CreateMovieReview(MovieReviewCreateDTO movieReviewCreateDto, int movieId)
        {
            var movie = Get(movieId);
            var movieReview = new MovieReview
            {
                Movie = movie,
                ReviewerName = movieReviewCreateDto.ReviewerName,
                Review = movieReviewCreateDto.Review
            };

            _movieReviewRepository.Insert(movieReview);
            _movieReviewRepository.Commit();

            return movieReview;
        }

        public ICollection<MovieReview> GetMovieReviewsByMovieId(int movieId)
        {
            var movie = Get(movieId);
            return _movieReviewRepository.GetReviewsByMovieId(movie.Id);
        }

        public void Delete(int id)
        {
            var movie = Get(id);
            _movieRepository.Delete(movie);
            _movieRepository.Commit();
        }
        
    }
}