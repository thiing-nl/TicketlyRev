using System.Collections.Generic;
using Screend.Data;
using Screend.Entities.LostItem;

namespace Screend.Repositories
{
    public interface ILostItemRepository : IRepository<LostItem>
    {
        IEnumerable<LostItem> GetAllByLocationId(int locationId);
    }
    
    public class LostItemRepository : BaseRepository<LostItem>, ILostItemRepository
    {
        private DatabaseContext _context;
        
        public LostItemRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<LostItem> GetAllByLocationId(int locationId)
        {
            return Get(it => it.LocationId == locationId);
        }
    }
}