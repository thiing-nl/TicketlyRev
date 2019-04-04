using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Moq;
using Screend.Entities.Order;
using Screend.Entities.User;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests.Services
{
   
    public class UserServiceTest
    {
        private static UserService _userService;
        private static string username = "manager";
        private static string password = "manager";
        private static string encryptedPassword;
        
        static UserServiceTest()
        {
            setupUserService();
        }

        private static void setupUserService()
        {
            var userRepository = new Mock<IUserRepository>();
            var configuration = new Mock<IConfiguration>();
            
            encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            
            userRepository.Setup(ur => ur.GetUserByUsername("manager"))
                .Returns(new User
                {
                    Id = 1,
                    Username = username,
                    FirstName = "manager",
                    LastName = "manager",
                    Password = encryptedPassword,
                    Tokens = new List<UserToken>(),
                    Orders = new List<Order>(),
                    AccountType = AccountType.Screen
                });

            configuration.Setup(x => x["secret"]).Returns("ticketly-test-secret");

            _userService = new UserService(userRepository.Object, configuration.Object);
        }
        
        
        [Fact]
        public void AuthenticateUserTest()
        {
            var user = _userService.Authenticate(username, password);
            Assert.IsType<User>(user);
        }
    }
}