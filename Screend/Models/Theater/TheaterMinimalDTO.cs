using System.Collections.Generic;
using Screend.Models.Order;

namespace Screend.Models.Theater
{
    public class TheaterMinimalDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool WheelchairAccessible { get; set; }
        
        public bool Has3D { get; set; }
    }
}