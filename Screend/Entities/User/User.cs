using System.Collections.Generic;

namespace Screend.Entities.User
{
    public enum AccountType
    {
        User = 0,
        Manager = 1,
        Screen = 2,
        Cashier = 3
    }
    
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public AccountType AccountType { get; set; } = AccountType.User;
        
        public virtual ICollection<Order.Order> Orders { get; set; }
        
        public virtual ICollection<UserToken> Tokens { get; set; }
    }
}