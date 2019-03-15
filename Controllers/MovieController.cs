using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var movies = _movieService.GetAll();
         
            return Ok(movies.Select(movie => new MovieWithScheduleDTO
            {
                Movie = Mapper.Map<MovieDTO>(movie),
                Schedule = Mapper.Map<ICollection<MovieScheduleDTO>>(_scheduleService.GetByMovie(movie.Id)) 
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