using System;
using Screend.Models.Theater;

namespace Screend.Models.Movie
{
    public class MovieScheduleDTO
    {
        public int Id { get; set; }
        
        public DateTime Time { get; set; }
        
        public TheaterDTO Theater { get; set; }  
    }
}