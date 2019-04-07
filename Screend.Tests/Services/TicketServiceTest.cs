using System.Collections.Generic;
using System.Linq;
using Moq;
using Screend.Entities.Order;
using Screend.Entities.Schedule;
using Screend.Entities.Ticket;
using Screend.Exceptions;
using Xunit;
using Screend.Services;
using Screend.Repositories;

namespace Screend.Tests.Services
{
    public class TicketServiceTest
    {
        static int ScheduleId = 1;
        static string TicketTitle = "Ticket title";
        private static ITicketService _ticketService;
        
        static TicketServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            var scheduleTicketRepository = new Mock<IScheduleTicketRepository>();

            var scheduleTickets = new List<ScheduleTicket>();
            
            scheduleTickets.Add(new ScheduleTicket
            {
                Id = ScheduleId,
                ScheduleId = 1,
                TicketId = 1,
                Schedule = new Schedule(),
                Ticket = new Ticket
                {
                    Id = 1,
                    Price = 10.89,
                    ScheduleTickets = new List<ScheduleTicket>(),
                    Title = TicketTitle
                }
            });
            
            scheduleTicketRepository.Setup(x => x.GetTicketsByScheduleId(ScheduleId)).Returns(scheduleTickets);
            
            _ticketService = new TicketService(scheduleTicketRepository.Object);
        }

        [Fact]
        public void GetTicketsByScheduleTest()
        {
            var tickets = _ticketService.GetTicketsBySchedule(ScheduleId).ToArray();
            Assert.Equal(TicketTitle, tickets[0].Title);
        }
    }
}