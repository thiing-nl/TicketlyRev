using System.Collections.Generic;

namespace Screend.Entities.Theater
{
    public class Theater
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool Has3D { get; set; }
        
        public bool WheelchairAccessible { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location.Location Location { get; set; }

        public virtual ICollection<TheaterRow> Rows { get; set; }
        
        public virtual ICollection<Schedule.Schedule> Schedules { get; set; }
    }
}