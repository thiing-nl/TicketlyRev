using Screend.Data;
using Screend.Entities.Order;

namespace Screend.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
    
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private DatabaseContext _context;
        
        public OrderRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}