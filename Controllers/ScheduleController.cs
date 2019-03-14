using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Models.Schedule;
using Screend.Repositories;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/schedule")]
    public class ScheduleController : BaseController
    {

        private readonly IScheduleService _scheduleRepository;
        public ScheduleController(IScheduleService scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        
        #region GetRoutes

        [HttpGet("day")]
        [ProducesResponseType(typeof(ICollection<ScheduleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetByDay()
        {
            DateTime date = new DateTime();
            var schedules = _scheduleRepository.GetByDay(date);
            return Ok(Mapper.Map<ScheduleDTO>(schedules));
        }

        [HttpGet("week")]
        public IActionResult GetByWeek()
        {
            return Ok();
        }
        
        #endregion
        
    }
}