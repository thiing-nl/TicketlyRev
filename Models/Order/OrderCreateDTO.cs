using System.Collections.Generic;

namespace Screend.Models.Order
{
    public class OrderCreateDTO
    {
        public int ScheduleId { get; set; }
        public string Amount { get; set; }
        public string ReturnUrl { get; set; }
        public ICollection<OrderCreateChairDTO> OrderChairs { get; set; }
    }
}