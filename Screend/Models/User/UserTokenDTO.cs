using System;

namespace Screend.Models.User
{
    public class UserTokenDTO
    {
        public int Id { get; set; }
        
        public string Token { get; set; }
        
        public DateTime ValidFrom { get; set; }
        
        public DateTime ValidTo { get; set; }
        
        public int UserId { get; set; }
    }
}