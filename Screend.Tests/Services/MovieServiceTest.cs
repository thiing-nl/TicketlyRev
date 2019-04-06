using Moq;
using Xunit;
using Screend.Services;
using Screend.Repositories;
using Screend.Entities.Movie;
using System.Collections.Generic;

namespace Screend.Tests.Services
{
    public class MovieServiceTest
    {
        private static int movieId = 1;
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
            
            movieRepository.Setup(x => x.GetByID(movieId)).Returns(mockMovie);
            
            _movieService = new MovieService(
                movieRepository.Object, 
                locationRepository.Object
            );
        }
        
    }
}