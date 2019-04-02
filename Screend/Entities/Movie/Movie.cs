using System.Collections.Generic;

namespace Screend.Entities.Movie
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Director { get; set; }
        
        public int Runtime { get; set; }
        
        public string Language { get; set; }
        
        public string Age { get; set; }
        
        public string Genre { get; set; }
        
        public string Rating { get; set; }
        
        public string Img { get; set; }
        
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        
    }
}