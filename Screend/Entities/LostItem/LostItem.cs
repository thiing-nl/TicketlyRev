namespace Screend.Entities.LostItem
{
    public enum LostItemState
    {
        Unknown = 0,
        Searching = 1,
        Found = 2,
        Halted = 3
    }
    
    public class LostItem
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public LostItemState State { get; set; } = LostItemState.Unknown;
        
        public int LocationId { get; set; }
        
        public virtual Location.Location Location { get; set; }
    }
}