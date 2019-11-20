using System.Collections.Generic;
using Screend.Entities.Location;

namespace Screend.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }
        
        public int Paid { get; set; }
        
        public string Amount { get; set; }
        
        public int UserId { get; set; }
        
        public string MollieId { get; set; }
        
        public int LocationMovieId { get; set; }
        
        public virtual LocationMovie LocationMovie { get; set; }
        
        public virtual User.User User { get; set; }
        
        public virtual ICollection<OrderArticle> OrderArticles { get; set; }
        
        public virtual ICollection<OrderChair> OrderChairs { get; set; }
    }
}