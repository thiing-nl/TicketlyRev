using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Screend.Entities.User;
using Screend.Exceptions;
using Screend.Models.User;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <exception cref="ForbiddenException"></exception>
        /// <returns>Authenticated User</returns>
        User Authenticate(string username, string password);

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="userRegisterDTO">User to be Registered</param>
        /// <exception cref="ForbiddenException"></exception>
        /// <returns>User</returns>
        User Register(UserRegisterDTO userRegisterDTO);

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <exception cref="NotFoundException">User not found</exception>
        /// <returns>User</returns>
        User Get(int userId);
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

        /// <inheritdoc cref="IUserService.Get" />
        public User Get(int userId)
        {
            var user = _userRepository.GetByID(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }

        /// <inheritdoc cref="IUserService.Authenticate" />
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

        /// <inheritdoc cref="IUserService.Register" />
        public User Register(UserRegisterDTO userRegisterDTO)
        {
            var user = _userRepository
                .FirstOrDefault(x => x.Username == userRegisterDTO.Username);

            // User doesn't exist
            if (user != null)
                throw new ForbiddenException("User with this username already exists.");

            // Map user
            var mappedUser = Mapper.Map<User>(userRegisterDTO);

            // Encrypt password
            mappedUser.Password = BCrypt.Net.BCrypt.HashPassword(mappedUser.Password);

            // Add user
            _userRepository.Insert(mappedUser);
            _userRepository.Commit();

            return mappedUser;
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