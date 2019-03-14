using Screend.Entities.User;

namespace Screend.Models.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public AccountType AccountType { get; set; }
        public bool Locked { get; set; } 
    }
}