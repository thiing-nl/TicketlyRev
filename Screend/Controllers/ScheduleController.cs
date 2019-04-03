using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Location;
using Screend.Entities.Schedule;
using Screend.Exceptions;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByDay(string time)
        {
            var date = DateTime.Now;
            
            if (time != null)
            {
                string[] input = time.Split("-");

                try
                {
                    date = new DateTime(
                        Int32.Parse(input[0]),
                        Int32.Parse(input[1]),
                        Int32.Parse(input[2]));
                }
                catch (Exception)
                {
                    throw new BadRequestException("Datetime not right formatted");
                }
               
            }
            
            var location = (Location) HttpContext.Items["Location"];
            
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

        #region PostRoutes

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateSchedule([FromBody] ScheduleCreateDTO scheduleCreateDto)
        {
            var location = (Location) HttpContext.Items["Location"];
            var schedule = _scheduleService.CreateSchedule(scheduleCreateDto, location);
            return Ok(MapSchedule(schedule));
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