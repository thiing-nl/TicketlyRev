using System.Collections.Generic;

namespace Screend.Models.Theater
{
    public class TheaterRowDTO
    {
        public int Id { get; set; }
        public char RowName { get; set; }
        public ICollection<TheaterChairDTO> TheaterChairs { get; set; }
    }
}