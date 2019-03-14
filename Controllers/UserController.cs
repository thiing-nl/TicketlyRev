using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        #endregion

    }
}