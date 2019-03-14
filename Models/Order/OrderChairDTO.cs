using Screend.Models.Theater;

namespace Screend.Models.Order
{
    public class OrderChairDTO
    {
        public int Id { get; set; }
        
        public OrderDTO Order { get; set; }
        
        public TheaterRowDTO TheaterRow { get; set; }
    }
}