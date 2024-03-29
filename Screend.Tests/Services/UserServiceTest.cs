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
        private static int UserId = 1;
        private static string username = "manager";
        private static string password = "manager";
        private static string encryptedPassword;
        
        static UserServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            var userRepository = new Mock<IUserRepository>();
            var configuration = new Mock<IConfiguration>();
            
            encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Id = UserId,
                Username = username,
                FirstName = "manager",
                LastName = "manager",
                Password = encryptedPassword,
                Tokens = new List<UserToken>(),
                Orders = new List<Order>(),
                AccountType = AccountType.Screen
            };
            
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            
            userRepository.Setup(u => u.GetByID(UserId)).Returns(user);
            userRepository.Setup(ur => ur.GetUserByUsername("manager"))
                .Returns(user);
            userRepository.Setup(u => u.GetUserByUsername(username)).Returns(null as User);

            configuration.Setup(x => x["secret"]).Returns("ticketly-test-secret");

            _userService = new UserService(userRepository.Object, configuration.Object);
        }
        
        
        [Fact]
        public void AuthenticateUserTest()
        {
            var user = _userService.Authenticate(username, password);
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
            var user = _userService.Get(UserId);
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