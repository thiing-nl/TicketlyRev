using Screend.Entities.LostItem;

namespace Screend.Models.LostItem
{
    public class LostItemCreateUpdateDTO
    {
        public string Description { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public LostItemState State { get; set; }
    }
}