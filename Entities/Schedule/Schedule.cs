using System;

namespace screend.Entities.Schedule
{
    public class Schedule
    {
        public int Id { get; set; }
        
        public DateTime Time { get; set; }

        public int MovieId { get; set; }
        
        public int TheaterId { get; set; }

        public virtual Theater.Theater Theater { get; set; }
        
        public virtual Movie.Movie Movie { get; set; }
    }
}