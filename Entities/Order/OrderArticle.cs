using screend.Entities.Theater;

namespace screend.Entities.Order
{
    public class OrderArticle
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int ArticleId { get; set; }
        
        public virtual Order Order { get; set; }
        
        public virtual TheaterArticle Article { get; set; }
    }
}