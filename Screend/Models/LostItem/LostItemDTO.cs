using Screend.Entities.LostItem;
using Screend.Models.Location;

namespace Screend.Models.LostItem
{
    public class LostItemDTO
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public LostItemState State { get; set; }
        
        public LocationMinimalDTO Location { get; set; }
    }
}