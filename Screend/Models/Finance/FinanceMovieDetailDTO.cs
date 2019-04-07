using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Screend.Models.Schedule;

namespace Screend.Models.Finance
{
    public class FinanceMovieDetailDTO
    {
        public IEnumerable<ScheduleDTO> Schedules { get; set; }
        
        public double Turnover { get; set; }
    }
}