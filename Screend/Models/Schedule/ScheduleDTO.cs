using System;
using Screend.Models.Movie;
using Screend.Models.Theater;

namespace Screend.Models.Schedule
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        
        public DateTime Time { get; set; }

        public int AmountFree { get; set; } = 0;
        
        public double Turnover { get; set; } = 0;
        
        public TheaterDTO Theater { get; set; }      
        
        public MovieDTO Movie { get; set; }
    }
}