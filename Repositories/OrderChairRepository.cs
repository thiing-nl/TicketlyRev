using Screend.Data;
using Screend.Entities.Order;

namespace Screend.Repositories
{
    public interface IOrderChairRepository : IRepository<OrderChair>
    {}
    
    public class OrderChairRepository : BaseRepository<OrderChair>, IOrderChairRepository
    {
        private readonly DatabaseContext _context;

        public OrderChairRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}