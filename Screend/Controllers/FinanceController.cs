using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Location;
using Screend.Exceptions;
using Screend.Filters;
using Screend.Models.Finance;
using Screend.Models.Schedule;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/finance")]
    [ServiceFilter(typeof(LocationFilter))]
    public class FinanceController : BaseController
    {
        private readonly IFinanceService _financeService;
        
        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }
        
        [HttpGet("/by-week")]
        [ProducesResponseType(typeof(FinanceMovieDetailDTO), StatusCodes.Status200OK)]
        public IActionResult GetFinanceWeekDetail(string weekDate)
        {
            var location = (Location) HttpContext.Items["Location"];
            var parsed = DateTime.TryParse(weekDate, out var date);

            if (!parsed)
            {
                throw new BadRequestException("Wrong date format");
            }
            
            return Ok(_financeService.GetFinanceWeekDetail(date, location.Id));
        }
    }
}