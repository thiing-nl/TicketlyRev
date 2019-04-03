using System.Collections.Generic;

namespace Screend.Models.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public ICollection<OrderChairDTO> OrderChairs { get; set; }
    }
}