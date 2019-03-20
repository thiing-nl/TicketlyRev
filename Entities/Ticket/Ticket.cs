using System.Collections.Generic;
using Screend.Entities.Schedule;

namespace Screend.Entities.Ticket
{
    public class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        
        public virtual ICollection<ScheduleTicket> ScheduleTickets { get; set; }
    }
}