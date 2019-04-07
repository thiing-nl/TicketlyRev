using System.Collections.Generic;
using Screend.Entities.Location;
using Screend.Models.Schedule;
using Screend.Models.Theater;

namespace Screend.Models.Location
{
    public class LocationMinimalDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
    }
}