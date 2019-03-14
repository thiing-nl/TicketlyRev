using System.Collections.Generic;
using Screend.Models.Order;
using Screend.Models.Theater;

namespace Screend.Models.Schedule
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public TheaterDTO Theater { get; set; }
        public ICollection<OrderChairDTO> OrderChairs { get; set; }
    }
}