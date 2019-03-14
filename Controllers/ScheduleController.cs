using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Schedule;
using Screend.Models.Schedule;
using Screend.Models.Theater;
using Screend.Repositories;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/schedule")]
    public class ScheduleController : BaseController
    {

        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        
        #region GetRoutes

        [HttpGet("day")]
        [ProducesResponseType(typeof(ICollection<ScheduleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetByDay()
        {
            DateTime date = DateTime.Now;
            var schedules = _scheduleService.GetByDay(date);

            var schedulesList = new List<ScheduleDTO>();
            foreach (var schedule in schedules)
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
                
                schedulesList.Add(mappedSchedule);
            }

            return Ok(schedulesList.ToArray());
        }
        
        #endregion
        
    }
}