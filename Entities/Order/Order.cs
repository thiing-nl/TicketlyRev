using System.Collections.Generic;

namespace screend.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }
        
        public int Paid { get; set; }
        
        public int UserId { get; set; }
        
        public string MollieId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual ICollection<OrderArticle> OrderArticles { get; set; }
        
        public virtual ICollection<OrderChair> OrderChairs { get; set; }
    }
}