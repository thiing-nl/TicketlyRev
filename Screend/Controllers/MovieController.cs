using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Location;
using Screend.Filters;
using Screend.Models.Movie;
using Screend.Services;

namespace Screend.Controllers
{

    [Route("api/movies")]
    [ServiceFilter(typeof(LocationFilter))]
    public class MovieController : BaseController
    {

        private readonly IMovieService _movieService;
        private readonly IScheduleService _scheduleService;

        public MovieController(IMovieService movieService, IScheduleService scheduleService)
        {
            _movieService = movieService;
            _scheduleService = scheduleService;
        }

        #region GetRoutes
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<MovieWithScheduleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var location = (Location) HttpContext.Items["Location"];
            var movies = _movieService.GetAllMoviesByLocation(location.Id);
         
            return Ok(movies.Select(movie => new MovieWithScheduleDTO
            {
                Movie = Mapper.Map<MovieDTO>(movie),
                Schedule = Mapper.Map<ICollection<MovieScheduleDTO>>(_scheduleService.GetByMovie(movie.Id, location.Id)) 
            }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {        
            var movie = _movieService.Get(id);
            return Ok(Mapper.Map<MovieDTO>(movie));
        }

        [HttpGet("{id}/reviews")]
        [ProducesResponseType(typeof(ICollection<MovieReviewDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReviewsByMovieId(int id)
        {
            var movieReviews = _movieService.GetMovieReviewsByMovieId(id);
            return Ok(Mapper.Map<ICollection<MovieReviewDTO>>(movieReviews));
        }
        
        #endregion
       
        #region PostRoutes

        [HttpPost("{id}/reviews")]
        [ProducesResponseType(typeof(MovieReviewDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateReview(int id, [FromBody] MovieReviewCreateDTO reviewCreateDto)
        {
            var movieReview = _movieService.CreateMovieReview(reviewCreateDto,id);
            return Ok(Mapper.Map<MovieReviewDTO>(movieReview));
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovieDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateMovie([FromBody] MovieCreateDTO movieCreateDto)
        {
            var movie = _movieService.CreateMovie(movieCreateDto);
            return Ok(Mapper.Map<MovieDTO>(movie));
        }

        #endregion
        
        #region DeleteRoutes

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
        
        #endregion
        
    }
}