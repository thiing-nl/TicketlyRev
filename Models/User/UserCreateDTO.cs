using System.ComponentModel.DataAnnotations;
using Screend.Entities.User;

namespace Screend.Models.User
{
    public class UserCreateDTO
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        public AccountType AccountType { get; set; } = AccountType.User;

        public bool Locked { get; set; } = false;
    }
}