namespace Screend.Entities.Schedule
{
    public class ScheduleTicket
    {
        
        public int Id { get; set; }
        
        public int ScheduleId { get; set; }
        
        public int TicketId { get; set; }
        
        public virtual Schedule Schedule { get; set; }
        
        public virtual Ticket.Ticket Ticket { get; set; }
        
    }
}