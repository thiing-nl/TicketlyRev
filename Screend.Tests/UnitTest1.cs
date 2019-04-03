using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using Moq;
using Screend.Entities.Order;
using Screend.Entities.User;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests
{
    public class UnitTest1
    {
        [Fact]
        public static void AuthenticateUser()
        {
            var userRepository = new Mock<IUserRepository>();
            string username = "manager";
            string password = "manager";
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            
            userRepository.Setup(ur => ur.FirstOrDefault(it => it.Username == "manager"))
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

            UserService userService = new UserService(userRepository.Object);

            var user = userService.Authenticate(username, password);
            Assert.IsType<User>(user);
        }
    }
}
