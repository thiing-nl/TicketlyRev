using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Screend.Data;
using Screend.Entities.User;

namespace Screend.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
    }
    
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private DatabaseContext _context;
        
        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return FirstOrDefault(x => x.Username == username);
        }
    }
}