using System;
using System.Collections.Generic;
using Screend.Entities.Order;

namespace Screend.Entities.Schedule
{
    public class Schedule
    {
        public int Id { get; set; }
        
        public DateTime Time { get; set; }

        public int MovieId { get; set; }
        
        public int TheaterId { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location.Location Location { get; set; }

        public virtual Theater.Theater Theater { get; set; }
        
        public virtual Movie.Movie Movie { get; set; }
        
        public virtual ICollection<OrderChair> OrderChairs { get; set; }
        
        public virtual ICollection<ScheduleTicket> ScheduleTickets { get; set; }
    }
}