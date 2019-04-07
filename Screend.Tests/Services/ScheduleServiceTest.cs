using System;
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
        static ScheduleServiceTest()
        {
            Setup();
        }

        private static ScheduleService _scheduleService;
        private static DateTime _dateNow;
        private static DateTime _dateTomorrow;
        private static DateTime _dateEndWeek;

        private static void Setup()
        {
            _dateNow = DateTime.Now;
            var next = _dateNow.AddDays(1);
            var end = new DateTime(
                next.Year,
                next.Month,
                next.Day
            );
            _dateTomorrow = end;
            _dateEndWeek = DateTime.Today.AddDays(7);

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
                    ScheduleTickets = new List<ScheduleTicket>()
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
                    ScheduleTickets = new List<ScheduleTicket>()
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
                    ScheduleTickets = new List<ScheduleTicket>()
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
                    ScheduleTickets = new List<ScheduleTicket>()
                }
            };

            scheduleRepository.Setup(sr => sr.GetByID(1)).Returns(new Schedule
            {
                Id = 1,
                Time = _dateNow,
                MovieId = 1,
                TheaterId = 1,
                LocationId = 1
            });

            scheduleRepository.Setup(sr => sr.GetSchedulesByDateRangeAndLocationId(_dateNow, _dateTomorrow, 1))
                .Returns(scheduleArray);
            scheduleRepository.Setup(sr => sr.GetSchedulesByDateRangeAndLocationId(_dateNow, _dateEndWeek, 1))
                .Returns(scheduleArray);

            scheduleRepository
                .Setup(sr => sr
                    .GetSchedulesByDateRangeAndLocationIdAndMovieId(
                        It.IsAny<DateTime>(), 
                        _dateEndWeek,
                        1,
                        1))
                .Returns(scheduleArray);

            _scheduleService = new ScheduleService(scheduleRepository.Object);
        }

        [Fact]
        private void GetByDayTest()
        {
            var schedules = _scheduleService.GetByDay(_dateNow, 1);
            Assert.Equal(4, schedules.Count);
        }

        [Fact]
        private void GetByIdTest()
        {
            var schedule = _scheduleService.GetById(1);
            Assert.IsType<Schedule>(schedule);
        }

        [Fact]
        private void GetByMovieTest()
        {
            var schedules = _scheduleService.GetByMovie(1, 1);
            Assert.Equal(4, schedules.Count);
        }

        [Fact]
        private void GetByWeekTest()
        {
            var schedules = _scheduleService.GetByWeek(_dateNow, 1);
            Assert.Equal(4, schedules.Count);
        }
    }
}