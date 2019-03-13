namespace Screend.Entities.Theater
{
    public class TheaterChair
    {
        public int Id { get; set; }
        
        public int ChairNumber { get; set; }
        
        public int TheaterRowId { get; set; }
        
        public virtual TheaterRow TheaterRow { get; set; }
    }
}