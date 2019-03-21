using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Location;
using Screend.Entities.Schedule;
using Screend.Filters;
using Screend.Models.Schedule;
using Screend.Models.Theater;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/schedule")]
    [ServiceFilter(typeof(LocationFilter))]
    public class ScheduleController : BaseController
    {

        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        #region GetRoutes

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ScheduleDTO), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var schedule = _scheduleService.GetById(id);
            
            return Ok(MapSchedule(schedule));
        }
        
        [HttpGet("day")]
        [ProducesResponseType(typeof(ICollection<ScheduleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetByDay()
        {
            var location = (Location) HttpContext.Items["Location"];
            DateTime date = DateTime.Now;
            var schedules = _scheduleService.GetByDay(date, location.Id)
                .Select(MapSchedule);
            
            return Ok(schedules.ToArray());
        }

        [HttpGet("week")]
        [ProducesResponseType(typeof(ICollection<ScheduleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetByWeek()
        {
            var location = (Location) HttpContext.Items["Location"];
            DateTime date = DateTime.Now;
            var schedules = _scheduleService.GetByWeek(date, location.Id)
                .Select(MapSchedule);
            
            return Ok(schedules.ToArray());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Map Schedule to ScheduleDTO
        /// -> this also sets the IsOccupied state
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        private static ScheduleDTO MapSchedule(Schedule schedule)
        {
            var mappedSchedule = Mapper.Map<ScheduleDTO>(schedule);
            foreach (var theaterRow in mappedSchedule.Theater.Rows)
            {
                foreach (var theaterChair in theaterRow.TheaterChairs)
                {
                    var isOccupied = schedule.OrderChairs.Any(it => it.TheaterChairId == theaterChair.Id);

                    if (isOccupied)
                    {
                        theaterChair.IsOccupied = ChairType.OCCUPIED;
                    }
                }
            }

            return mappedSchedule;
        }

        #endregion
    }
}