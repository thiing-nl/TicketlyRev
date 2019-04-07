using Moq;
using Xunit;
using Screend.Services;
using Screend.Repositories;
using Screend.Entities.Movie;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Location;
using Screend.Entities.Order;
using Screend.Entities.Schedule;
using Screend.Entities.Theater;
using Screend.Exceptions;

namespace Screend.Tests.Services
{
    public class MovieServiceTest
    {
        private static int movieId = 1;
        private static int locationId = 1;
        private static int locationMovieId = 1;
        private static MovieService _movieService;
        
        static MovieServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            var movieRepository = new Mock<IMovieRepository>();
            var locationRepository = new Mock<ILocationRepository>();

            var mockMovie = new Movie
            {
                Id = movieId,
                Title = "Test movie"
            };
            
            var mockLocationMovie = new LocationMovie
            {
                Id = locationMovieId,
                LocationId = locationId,
                MovieId = movieId,
                Movie = mockMovie,
                Orders = new List<Order>()
            };
            
            var mockLocationsMovies = new List<LocationMovie>();
            mockLocationsMovies.Add(mockLocationMovie);
            
            var mockLocation = new Location
            {
                Id = locationId,
                Name = "Tilburg",
                Address = "De straat in tilburg",
                Theaters = new List<Theater>(),
                Movies = mockLocationsMovies,
                Schedules = new List<Schedule>()
            };

            locationRepository.Setup(x => x.GetByID(locationId)).Returns(mockLocation);
            movieRepository.Setup(x => x.GetByID(movieId)).Returns(mockMovie);
            
            _movieService = new MovieService(
                movieRepository.Object, 
                locationRepository.Object
            );
        }

        [Fact]
        private void GetAllMoviesByLocationTest()
        {
            var movies = _movieService.GetAllMoviesByLocation(locationId).ToArray();
            Assert.True(movies[0].Id == movieId);
        }

        [Fact]
        private void GetByIdTest()
        {
            var movie = _movieService.Get(movieId);
            Assert.True(movie.Id == movieId);
        }

        [Fact]
        private void GetByIdNotFoundTest()
        {
            Assert.Throws<NotFoundException>(() => _movieService.Get(87));
        }

        [Fact]
        private void DeleteByIdTest()
        {
            var ex = Record.Exception(() => _movieService.Delete(movieId));
            Assert.Null(ex);
        }
        
    }
}