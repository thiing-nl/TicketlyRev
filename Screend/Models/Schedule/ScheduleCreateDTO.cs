using System;

namespace Screend.Models.Schedule
{
    public class ScheduleCreateDTO
    {
        public DateTime Time { get; set; }
        
        public int MovieId { get; set; }
        
        public int TheaterId { get; set; }
    }
}