using screend.Entities.Movie;
using screend.Entities.Theater;

namespace screend.Entities.Order
{
    public class OrderChair
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int ChairId { get; set; }
        
        public int TicketId { get; set; }
        
        public int ScheduleId { get; set; }
        
        public virtual Order Order { get; set; }
        
        public virtual TheaterChair TheaterChair { get; set; }
        
        public virtual Schedule.Schedule Schedule { get; set; }
        
        public virtual MovieTicket MovieTicket { get; set; }
    }
}