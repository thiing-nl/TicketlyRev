namespace Screend.Entities.Movie
{
    public class MovieReview
    {
        
        public int Id { get; set; }
        
        public int MovieId { get; set; }
        
        public string Review { get; set; }

        public string ReviewerName { get; set; }

        public virtual Movie Movie { get; set; }
        
    }
}