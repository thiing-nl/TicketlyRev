using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using Screend.Entities.Location;
using Screend.Entities.Movie;
using Screend.Entities.Order;
using Screend.Entities.Schedule;
using Screend.Entities.Theater;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests.Services
{
    public class ScheduleServiceTest
    {
        private static ScheduleService _scheduleService;
        private static DateTime _dateNow;
        private static DateTime _dateTomorrow;
        
        static ScheduleServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            
            _dateNow = DateTime.Now;
            _dateTomorrow = DateTime.Now.AddDays(1);
            
            var scheduleRepository = new Mock<IScheduleRepository>();

            var scheduleArray = new List<Schedule>
            {
                new Schedule
                {
                    Id = 1,
                    Time = _dateNow,
                    MovieId = 1,
                    TheaterId = 1,
                    LocationId = 1,
                    Location = new Location(),
                    Theater = new Theater(),
                    Movie = new Movie(),
                    OrderChairs = new List<OrderChair>(),
                    ScheduleTickets = new List<ScheduleTicket>(),
                },
                new Schedule
                {
                    Id = 2,
                    Time = _dateTomorrow,
                    MovieId = 2,
                    TheaterId = 1,
                    LocationId = 1,
                    Location = new Location(),
                    Theater = new Theater(),
                    Movie = new Movie(),
                    OrderChairs = new List<OrderChair>(),
                    ScheduleTickets = new List<ScheduleTicket>(),
                },
                new Schedule
                {
                    Id = 3,
                    Time = _dateTomorrow,
                    MovieId = 1,
                    TheaterId = 1,
                    LocationId = 1,
                    Location = new Location(),
                    Theater = new Theater(),
                    Movie = new Movie(),
                    OrderChairs = new List<OrderChair>(),
                    ScheduleTickets = new List<ScheduleTicket>(),
                },
                new Schedule
                {
                    Id = 4,
                    Time = _dateNow,
                    MovieId = 1,
                    TheaterId = 1,
                    LocationId = 2,
                    Location = new Location(),
                    Theater = new Theater(),
                    Movie = new Movie(),
                    OrderChairs = new List<OrderChair>(),
                    ScheduleTickets = new List<ScheduleTicket>(),
                },
            };
            
            scheduleRepository.Setup(sr => sr.GetByID(1)).Returns(new Schedule
            {
                Id = 1,
                Time = _dateNow,
                MovieId = 1,
                TheaterId = 1,
                LocationId = 1,
            });
            
            scheduleRepository.Setup(sr => sr.GetSchedulesByDateRangeAndLocationId(_dateNow, _dateTomorrow, 1)).Returns(scheduleArray);
            
            scheduleRepository.Setup(sr => sr.GetSchedulesByDateRangeAndLocationIdAndMovieId(_dateNow, _dateTomorrow, 1, 1)).Returns(scheduleArray);
            
            _scheduleService = new ScheduleService(scheduleRepository.Object);
        }
        
        [Fact]
        private void GetByDayTest()
        {
            var schedules = _scheduleService.GetByDay(_dateNow, 1);
            Assert.Equal(2, schedules.Count);
        }
        
        [Fact]
        private void GetByWeekTest()
        {
            var schedules = _scheduleService.GetByWeek(_dateNow, 1);
            Assert.Equal(2, schedules.Count);
        }

        [Fact]
        private void GetByMovieTest()
        {
            var schedules = _scheduleService.GetByMovie(1, 1);
            Assert.Equal(3, schedules.Count);
        }

        [Fact]
        private void GetByIdTest()
        {
            var schedule = _scheduleService.GetById(1);
            Assert.IsType<Schedule>(schedule);
        }
    }
}