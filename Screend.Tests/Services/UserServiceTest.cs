using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using Screend.Entities.Order;
using Screend.Entities.User;
using Screend.Exceptions;
using Screend.Models.User;
using Screend.Profiles;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests.Services
{
   
    public class UserServiceTest
    {
        private static UserService _userService;
        private static int userId = 1;
        private static int userId2 = 2;
        private static string username = "manager";
        private static string username2 = "manager2";
        private static string password = "manager";
        private static string encryptedPassword;
        
        static UserServiceTest()
        {
            Helper.SetupAutoMapper();
            Setup();
        }

        private static void Setup()
        {
            var userRepository = new Mock<IUserRepository>();
            var configuration = new Mock<IConfiguration>();
            
            encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Id = userId,
                Username = username,
                FirstName = "manager",
                LastName = "manager",
                Password = encryptedPassword,
                Tokens = new List<UserToken>(),
                Orders = new List<Order>(),
                AccountType = AccountType.Screen
            };
            
            var user2 = new User
            {
                Id = userId2,
                Username = username2,
                FirstName = "manager",
                LastName = "manager",
                Password = encryptedPassword,
                Tokens = new List<UserToken>(),
                Orders = new List<Order>(),
                AccountType = AccountType.Manager
            };
            
            userRepository.Setup(u => u.GetByID(userId)).Returns(user);
            userRepository.Setup(ur => ur.GetUserByUsername("manager"))
                .Returns(user);
            userRepository.Setup(u => u.GetUserByUsername(username)).Returns(null as User);
            userRepository.Setup(u => u.GetUserByUsername(username2)).Returns(user2);

            configuration.Setup(x => x["secret"]).Returns("ticketly-test-secret");

            _userService = new UserService(userRepository.Object, configuration.Object);
        }
        
        
        [Fact]
        public void AuthenticateUserTest()
        {
            var user = _userService.Authenticate(username2, password);
            Assert.IsType<User>(user);
        }

        [Fact]
        public void GetByIdNotFoundTest()
        {
            Assert.Throws<NotFoundException>(() => _userService.Get(88));
        }
        
        [Fact]
        public void GetByIdTest()
        {
            var user = _userService.Get(userId);
            Assert.IsType<User>(user);
        }

        [Fact]
        public void RegisterTest()
        {
            var registerDTO = new UserRegisterDTO
            {
                FirstName = "manager",
                LastName = "manager",
                Username = username,
                Password = password
            };
            
            var user = _userService.Register(registerDTO);
            Assert.IsType<User>(user);
        }
    }
}