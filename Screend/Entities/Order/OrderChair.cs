using Screend.Entities.Movie;
using Screend.Entities.Theater;

namespace Screend.Entities.Order
{
    public class OrderChair
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int TheaterChairId { get; set; }
        
        public int TicketId { get; set; }
        
        public int ScheduleId { get; set; }
        
        public virtual Order Order { get; set; }
        
        public virtual TheaterChair TheaterChair { get; set; }
        
        public virtual Schedule.Schedule Schedule { get; set; }
        
        public virtual Ticket.Ticket Ticket { get; set; }
    }
}