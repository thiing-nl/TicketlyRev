using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Screend.Models.Location;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/locations")]
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _locationService.GetAll();
            return Ok(Mapper.Map<ICollection<LocationDTO>>(locations));
        }
    }
}