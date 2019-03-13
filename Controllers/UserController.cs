using System;
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
        
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok();
        }

        #endregion
        
        #region PostRoutes
       
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(UserTokenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate([FromBody] UserAuthenticateDTO userAuthenticateDTO)
        {
            var user = _userService.Authenticate(userAuthenticateDTO.Username, userAuthenticateDTO.Password);
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
        
        #endregion

    }
}