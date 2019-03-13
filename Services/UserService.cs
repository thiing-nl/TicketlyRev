using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Screend.Entities.User;
using Screend.Exceptions;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        
        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ForbiddenException"></exception>
        public User Authenticate(string username, string password)
        {
            var user = _userRepository
                .FirstOrDefault(x => x.Username == username);

            // Check if user exists
            if (user == null)
                throw new ForbiddenException("Username or password is incorrect");

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new ForbiddenException("Username or password is incorrect");

            // Issue token
            var issuedToken = IssueToken(user);
            user.Tokens.Add(new UserToken
            {
                Token = issuedToken.Token,
                ValidFrom = issuedToken.SecurityToken.ValidFrom,
                ValidTo = issuedToken.SecurityToken.ValidTo
            });
            _userRepository.Commit();

            // Return user object
            return user;
        }
        
        /// <summary>
        /// Issue token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Issued token</returns>
        private dynamic IssueToken(User user)
        {
            // Issue a token
            // Use JWT Security token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            
            // Get the secret
            var key = Encoding.ASCII.GetBytes(_configuration["secret"]);
            
            // Create the params for the token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            // Create the token
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            
            // Write the token to the token handler
            return new {
                SecurityToken = securityToken,
                Token = token
            };
        }
    }
}