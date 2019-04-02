using System.Collections;
using System.Collections.Generic;

namespace Screend.Entities.Location
{
    public class LocationMovie
    {
        public int Id { get; set; }
        
        public int LocationId { get; set; }

        public int MovieId { get; set; }
        
        public virtual Location Location { get; set; }

        public virtual Movie.Movie Movie { get; set; }
        
        public virtual ICollection<Order.Order> Orders { get; set; }
    }
}