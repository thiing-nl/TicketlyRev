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

        private readonly ITicketRepository _ticketRepository;
        private readonly IScheduleTicketRepository _scheduleTicketRepository;
        
        public TicketService(
            ITicketRepository ticketRepository,
            IScheduleTicketRepository scheduleTicketRepository
        )
        {
            _ticketRepository = ticketRepository;
            _scheduleTicketRepository = scheduleTicketRepository;

        }
        
        public ICollection<Ticket> GetTicketsBySchedule(int scheduleId)
        {
            ScheduleTicket[] scheduleTickets = 
                _scheduleTicketRepository.Get(st => st.ScheduleId == scheduleId).ToArray();

            ICollection<Ticket> tickets = new List<Ticket>();

            foreach (var ticket in scheduleTickets)
            {
                tickets.Add(ticket.Ticket);
            }

            return tickets;
        }
    }
}