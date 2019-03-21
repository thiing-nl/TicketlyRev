using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.User;
using Screend.Exceptions;
using Screend.Models.User;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region GetRoutes
        
        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns>Received user</returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="InternalServerErrorException"></exception>
        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Me()
        {
            var nameIdentifierClaim = HttpContext.User.Claims.FirstOrDefault(it => it.Type == ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim == null)
            {
                throw new InternalServerErrorException("Cannot convert token into user.");
            }

            int.TryParse(nameIdentifierClaim.Value, out var parsedUserId);
                
            return Ok(Mapper.Map<UserDTO>(_userService.Get(parsedUserId)));
        }
        
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>All users</returns>
        /// <exception cref="ForbiddenException"></exception>
        /// <exception cref="InternalServerErrorException"></exception>
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            MakeSureIsManager();
                
            return Ok(Mapper.Map<ICollection<UserDTO>>(_userService.GetAll()));
        }

        #endregion
        
        #region PostRoutes
       
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="userAuthenticateDTO"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(AuthorizedUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Authenticate([FromBody] UserAuthenticateDTO userAuthenticateDTO)
        {
            // Authenticate User
            var user = _userService.Authenticate(userAuthenticateDTO.Username, userAuthenticateDTO.Password);
            
            return Ok(Mapper.Map<AuthorizedUserDTO>(user));
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="userRegisterDTO">User to be registered</param>
        /// <returns>Registered user</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var user = _userService.Register(userRegisterDTO);
            
            return Ok(Mapper.Map<UserDTO>(user));
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="userCreateDTO">User to be created</param>
        /// <returns>Created user</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
        {
            MakeSureIsManager();
            
            var user = _userService.Create(userCreateDTO);
            
            return Ok(Mapper.Map<UserDTO>(user));
        }
        
        #endregion
        
        /// <summary>
        /// Delete All
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteAll()
        {
            MakeSureIsManager();
            _userService.DeleteAll();
            
            return Ok();
        }
        
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">Id of User</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Delete(int id)
        {
            MakeSureIsManager();
            _userService.Delete(id);
            
            return Ok();
        }

        #region Private Methods
        

        /// <summary>
        /// This makes sure the logged in user is a Manager
        /// </summary>
        /// <exception cref="InternalServerErrorException"></exception>
        /// <exception cref="ForbiddenException"></exception>
        private void MakeSureIsManager()
        {
            var nameIdentifierClaim = HttpContext.User.Claims.FirstOrDefault(it => it.Type == ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim == null)
            {
                throw new InternalServerErrorException("Cannot convert token into user.");
            }

            int.TryParse(nameIdentifierClaim.Value, out var parsedUserId);
            var user = _userService.Get(parsedUserId);

            if (user.AccountType != AccountType.Manager)
            {
                throw new ForbiddenException("Cannot use this call as a normal user. Only managers.");
            }
        }
        
        #endregion
    }
}