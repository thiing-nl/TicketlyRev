using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Models.Movie;
using Screend.Services;

namespace Screend.Controllers
{

    [Route("api/movies")]
    public class MovieController : BaseController
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        #region GetRoutes
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<MovieDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            return Ok(Mapper.Map<ICollection<MovieDTO>>(movies));
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