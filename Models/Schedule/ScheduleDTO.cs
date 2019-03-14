using System;
using Screend.Models.Movie;
using Screend.Models.Theater;

namespace Screend.Models.Schedule
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        
        public DateTime Time { get; set; }
        
        public TheaterDTO Theater { get; set; }      
        
        public MovieDTO Movie { get; set; }
    }
}