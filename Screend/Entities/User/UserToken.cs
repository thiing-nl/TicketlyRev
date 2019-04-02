using System;

namespace Screend.Entities.User
{
    public class UserToken
    {
        public int Id { get; set; }
        
        public string Token { get; set; }
        
        public DateTime ValidFrom { get; set; }
        
        public DateTime ValidTo { get; set; }
        
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}