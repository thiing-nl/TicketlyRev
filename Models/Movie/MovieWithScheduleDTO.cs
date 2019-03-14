using System;
using System.Collections;
using System.Collections.Generic;
using Screend.Models.Schedule;
using Screend.Models.Theater;

namespace Screend.Models.Movie
{
    public class MovieWithScheduleDTO
    {
        public MovieDTO Movie { get; set; }
        
        public ICollection<MovieScheduleDTO> Schedule { get; set; }
    }
}