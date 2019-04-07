using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IFinanceService _financeService;
        private readonly IScheduleService _scheduleService;

        public MovieController(IMovieService movieService, IScheduleService scheduleService, IFinanceService financeService)
        {
            _movieService = movieService;
            _scheduleService = scheduleService;
            _financeService = financeService;
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
                Turnover = _financeService.GetTurnover(movie.Id, location.Id),
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