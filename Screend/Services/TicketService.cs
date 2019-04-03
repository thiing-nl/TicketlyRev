using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Schedule;
using Screend.Entities.Ticket;
using Screend.Repositories;

namespace Screend.Services
{
    public interface ITicketService
    {

        ICollection<Ticket> GetTicketsBySchedule(int scheduleId);

    }
    
    public class TicketService : BaseService, ITicketService
    {
        private readonly IScheduleTicketRepository _scheduleTicketRepository;
        
        public TicketService(
            IScheduleTicketRepository scheduleTicketRepository
        )
        {
            _scheduleTicketRepository = scheduleTicketRepository;
        }
        
        public ICollection<Ticket> GetTicketsBySchedule(int scheduleId)
        {
            ICollection<ScheduleTicket> scheduleTickets = 
                _scheduleTicketRepository.GetTicketsByScheduleId(scheduleId);

            ICollection<Ticket> tickets = new List<Ticket>();

            foreach (var ticket in scheduleTickets)
            {
                tickets.Add(ticket.Ticket);
            }

            return tickets;
        }
    }
}