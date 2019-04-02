
namespace Screend.Models.User
{
    public class AuthorizedUserDTO : UserDTO
    {
        public UserTokenDTO Token { get; set; }
    }
}