using System.ComponentModel.DataAnnotations;

namespace Screend.Models.User
{
    public class UserAuthenticateDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; } 
    }
}