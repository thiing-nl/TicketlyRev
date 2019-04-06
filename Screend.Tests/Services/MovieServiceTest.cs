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
            setup();
        }

        private static void setup()
        {
            var movieRepository = new Mock<IMovieRepository>();
            var locationRepository = new Mock<ILocationRepository>();
            var movieReviewRepository = new Mock<IMovieReviewRepository>();
            var locationMovieRepository = new Mock<ILocationMovieRepository>();

            var mockMovie = new Movie
            {
                Id = movieId,
                Title = "Test movie"
            };
            
            movieRepository.Setup(x => x.GetByID(movieId)).Returns(mockMovie);
            movieReviewRepository.Setup(x => x.GetReviewsByMovieId(movieId)).Returns(new List<MovieReview>());
            
            _movieService = new MovieService(
                movieRepository.Object, 
                locationRepository.Object,
                movieReviewRepository.Object,
                locationMovieRepository.Object
            );
        }
        
        [Fact]
        public void GetMovieReviewsByMovieIdTest()
        {
            var reviews = _movieService.GetMovieReviewsByMovieId(movieId);
            Assert.IsType<List<MovieReview>>(reviews);
        }
    }
}