using System.Collections.Generic;
using Screend.Models.Order;

namespace Screend.Models.Theater
{
    public class TheaterDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool WheelchairAccessible { get; set; }
        
        public bool Has3D { get; set; }
        
        public ICollection<TheaterRowDTO> Rows { get; set; }
    }
}