using Screend.Repositories;

namespace Screend.Services
{
    public interface IUserService
    {
    }

    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}