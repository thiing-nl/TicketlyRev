using System.Collections.Generic;

namespace Screend.Entities.Location
{
    public class Location
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public virtual ICollection<Theater.Theater> Theaters { get; set; }
        
        public virtual ICollection<LocationMovie> Movies { get; set; }
        
        public virtual ICollection<Schedule.Schedule> Schedules { get; set; }
    }
}