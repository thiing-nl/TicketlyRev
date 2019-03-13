using System.Collections.Generic;

namespace Screend.Entities.Theater
{
    public class TheaterRow
    {
        public int Id { get; set; }
        
        public int TheaterId { get; set; }
        
        public char RowName { get; set; }
        
        public virtual Theater Theater { get; set; }
        
        public virtual ICollection<TheaterChair> TheaterChairs { get; set; }
    }
}