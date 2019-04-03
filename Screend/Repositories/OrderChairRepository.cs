using Screend.Data;
using Screend.Entities.Order;

namespace Screend.Repositories
{
    public interface IOrderChairRepository : IRepository<OrderChair>
    {
        OrderChair GetOrderChairByChairIdAndScheduleId(int chairId, int scheduleId);
    }
    
    public class OrderChairRepository : BaseRepository<OrderChair>, IOrderChairRepository
    {
        private readonly DatabaseContext _context;

        public OrderChairRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public OrderChair GetOrderChairByChairIdAndScheduleId(int chairId, int scheduleId)
        {
            return FirstOrDefault(it =>
                it.TheaterChairId == chairId && it.ScheduleId == scheduleId);
        }
    }
}